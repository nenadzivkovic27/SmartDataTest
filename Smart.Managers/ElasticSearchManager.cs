using Elasticsearch.Net;
using Nest;
using Smart.DataTypes;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Configuration;

namespace Smart.Managers
{
    public class ElasticSearchManager : ISearchManager
    {
        private string _address;
        private string _username;
        private string _password;

        public ElasticSearchManager(string elasticURL, string elasitcUsername, string elasticPassword)
        {
            _address = elasticURL;
            _username = elasitcUsername;
            _password = elasticPassword;
        }

        private ElasticClient _client;
        private ElasticClient Client
        {
            get
            {
                if (_client == null) _client = CreateElasticClient();
                return _client;
            }
        }

        private ElasticClient CreateElasticClient()
        {
            var uri = new Uri(_address);
            var connectionPool = new SingleNodeConnectionPool(uri);
            var settings = new ConnectionSettings(connectionPool).BasicAuthentication(_username, _password);
            //settings.ThrowExceptions(alwaysThrow: true);
            settings.PrettyJson();
            var client = new ElasticClient(settings);
            return client;
        }

        #region DataLoad

        public void CreateIndexes()
        {
            var mResponse = Client.Indices.Get("mgmt");

            if (mResponse.Indices.Count > 0)
            {
                var dropMgmtResponse = Client.Indices.Delete("mgmt");
            }
            var createMgmtResponse = Client.Indices.Create("mgmt", index => index
                .Settings(s => s
                   .Analysis(a => a.Analyzers(aa => aa
                       .Stop("my_analyzer", sa => sa
                           .StopWords("_english_")))))
                .Map<Mgmt>(x => x.AutoMap())
                );

            var pResponse = Client.Indices.Get("property");
            if (pResponse.Indices.Count >= 0)
            {
                var dropPropertyResponse = Client.Indices.Delete("property");
            }
            var createPropertyResponse = Client.Indices.Create("property", index => index
               .Settings(s => s
                   .Analysis(a => a.Analyzers(aa => aa
                       .Stop("my_analyzer", sa => sa
                           .StopWords("_english_")))))
               .Map<Property>(x => x.AutoMap())
               );
        }

        public void LoadMgmt(List<Mgmt> mgmtItems)
        {
            var delReponse = Client.DeleteByQuery<Mgmt>(del => del.Index("mgmt").Query(q => q.QueryString(qs => qs.Query("*"))));
            var indexResponse = Client.IndexMany(mgmtItems, "mgmt");
        }

        public void LoadProperty(List<Property> propertyItems)
        {
            var delReponse = Client.DeleteByQuery<Property>(del => del.Index("property").Query(q => q.QueryString(qs => qs.Query("*"))));
            var indexResponse = Client.IndexMany(propertyItems, "property");
        }

        #endregion

        #region Search Interface

        public GetMarketsResponse GetAllMarkets()
        {
            GetMarketsResponse toRet = new GetMarketsResponse();
            try
            {
                var response = Client.Search<Market>(s => s
                .Index("mgmt,property")
                .Size(0)
                .Aggregations(a => a.MultiTerms("Markets", m => m.Terms(t1 => t1.Field(f1 => f1.market.Suffix("keyword")), t2 => t2.Field(f2 => f2.state.Suffix("keyword")))))
                );

                var markets = response.Aggregations.MultiTerms("Markets");
                foreach (var item in markets.Buckets)
                {
                    var aggMarket = item.Key.ElementAt(0);
                    var aggState = item.Key.ElementAt(1);

                    Market m = new Market { market = aggMarket, state = aggState };
                    toRet.Markets.Add(m);
                }

                toRet.Markets = toRet.Markets.OrderBy(x => x.ToString()).ToList();
                toRet.Success = true;
            }
            catch (Exception ex)
            {
                toRet.Success = false;
                toRet.ErrorMessage = ex.Message; //TODO: something more meaningful for user
                //TODO: log error message
            }
            return toRet;
        }

        public SmartSearchResponse Search(SmartSearchRequest request)
        {
            SmartSearchResponse toRet = new();
            try
            {
                QueryContainer mgmtQuery = new QueryContainer();
                QueryContainer propertyQuery = new QueryContainer();

                //Building market/state query
                if (request.Market != null)
                {
                    if (!String.IsNullOrWhiteSpace(request.Market.market))
                    {
                        QueryContainer marketQuery
                            = Query<Mgmt>
                                .Match(m => m
                                    .Field(f => f.market.Suffix("keyword"))
                                    .Query(request.Market.market));

                        mgmtQuery &= marketQuery;
                        propertyQuery &= marketQuery;
                    }

                    if (!String.IsNullOrWhiteSpace(request.Market.state))
                    {
                        QueryContainer stateQuery
                            = Query<Mgmt>
                                .Match(m => m
                                    .Field(f => f.state.Suffix("keyword"))
                                    .Query(request.Market.state));

                        mgmtQuery &= stateQuery;
                        propertyQuery &= stateQuery;
                    }


                }

                //Building main search term query
                if (!String.IsNullOrWhiteSpace(request.SearchTerm))
                {
                    //for mgmt = only name
                    QueryContainer nameQuery
                           = Query<Mgmt>
                               .Match(m => m
                                   .Field(f => f.name)
                                   .Query(request.SearchTerm)
                                   .Operator(Operator.And)
                                   .Analyzer("my_analyzer")
                                   );


                    mgmtQuery &= nameQuery;

                    //for property = combination of all string fields
                    QueryContainer formerNameQuery
                          = Query<Property>
                              .Match(m => m
                                  .Field(f => f.formerName)
                                  .Query(request.SearchTerm)
                                  .Operator(Operator.And)
                                  .Analyzer("my_analyzer"));

                    QueryContainer streetAddessQuery
                        = Query<Property>
                            .Match(m => m
                                .Field(f => f.streetAddress)
                                .Query(request.SearchTerm)
                                .Operator(Operator.And)
                                .Analyzer("my_analyzer"));

                    QueryContainer cityQuery
                       = Query<Property>
                           .Match(m => m
                               .Field(f => f.city)
                               .Query(request.SearchTerm)
                               .Operator(Operator.And)
                               .Analyzer("my_analyzer"));

                    QueryContainer propertySearchQuery = nameQuery || formerNameQuery || streetAddessQuery || cityQuery;

                    propertyQuery &= propertySearchQuery;
                }

                //Searching for Mgmt
                SearchRequest searchMgmtRequest = new("mgmt");
                searchMgmtRequest.Query = mgmtQuery;
                searchMgmtRequest.Size = request.Limit;

                var searchMgmtResponse = Client.Search<Mgmt>(searchMgmtRequest);

                toRet.Mgmts = new List<Mgmt>(searchMgmtResponse.Documents);
                toRet.MgmtTotal = searchMgmtResponse.Total;

                //Searching for Properties
                SearchRequest searchProperyRequest = new("property");
                searchProperyRequest.Query = propertyQuery;
                searchProperyRequest.Size = request.Limit;

                var searchProperyResponse = Client.Search<Property>(searchProperyRequest);

                toRet.Properties = new List<Property>(searchProperyResponse.Documents);
                toRet.PropertiesTotal = searchProperyResponse.Total;

                toRet.Success = true;
            }
            catch (Exception ex)
            {
                toRet.Success = false;
                toRet.ErrorMessage = ex.Message; //TODO: something more meaningful for user
                //TODO: log error message
            }
            return toRet;
        }

        public GetMgmtResponse GetMgmt(int mgmtID)
        {
            GetMgmtResponse toRet = new GetMgmtResponse();
            try
            {
                var response = Client.Search<Mgmt>(s => s
                 .Index("mgmt")
                 .Query(q => q
                        .Match(m => m
                            .Field(f => f.mgmtID)
                            .Query(mgmtID.ToString()))
                    )
                 );

                toRet.Mgmts = response.Documents.ToList();
                toRet.MgmtTotal = response.Total;
                toRet.Success = true;
            }
            catch (Exception ex)
            {
                toRet.Success = false;
                toRet.ErrorMessage = ex.Message; //TODO: something more meaningful for user
                //TODO: log error message
            }
            return toRet;
        }

        public GetPropertyResponse GetProperty(int propertyID)
        {
            GetPropertyResponse toRet = new GetPropertyResponse();
            try
            {
                var response = Client.Search<Property>(s => s
                 .Index("property")
                 .Query(q => q
                        .Match(m => m
                            .Field(f => f.propertyID)
                            .Query(propertyID.ToString()))
                    )
                 );

                toRet.Properties = response.Documents.ToList();
                toRet.PropertiesTotal = response.Total;
                toRet.Success = true;
            }
            catch (Exception ex)
            {
                toRet.Success = false;
                toRet.ErrorMessage = ex.Message; //TODO: something more meaningful for user
                //TODO: log error message
            }
            return toRet;
        }

        #endregion
    }
}
