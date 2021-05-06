using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using SmartDemoApp.DemoAppDataTypes;
using SmartDemoApp.WebApiClasses;

namespace SmartDemoApp
{
    public class SmartAPIManager
    {

        #region Singleton
        private static SmartAPIManager instance = null;
        private static readonly object padlock = new object();

        public static SmartAPIManager Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new SmartAPIManager();
                    }
                    return instance;
                }
            }
        }
        #endregion

        private RestClient client;

        public SmartAPIManager()
        {
            string url = ConfigurationManager.AppSettings["SmartApiUrl"];
            client = new RestClient(url);
            //client.Authenticator = new HttpBasicAuthenticator("username", "password");
        }

        public List<MarketResult> GetMarkets()
        {
            List<MarketResult> toRet = new List<MarketResult>();
            MarketResult blanc = new MarketResult();
            toRet.Add(blanc);

            var request = new RestRequest("markets", DataFormat.Json);
            var response = client.Get(request);
            var json = response.Content;
            var marketResponse = JsonConvert.DeserializeObject<MarketResponse>(json);

            foreach (Market m in marketResponse.markets)
            {
                MarketResult mr = new MarketResult();
                mr.Market = m.market;
                mr.State = m.state;
                toRet.Add(mr);
            }

            return toRet;
        }

        public SearchResult Search(string searchTerm, MarketResult market, int limit)
        {
            SearchResult toRet = new SearchResult();

            SearchRequest searchRequest = new SearchRequest();
            searchRequest.limit = limit;
            searchRequest.searchTerm = searchTerm;
            searchRequest.market = new Market();
            searchRequest.market.market = market.Market;
            searchRequest.market.state = market.State;

            var request = new RestRequest("search", DataFormat.Json);
            request.AddJsonBody(searchRequest);

            var response = client.Post(request);
            var json = response.Content;
            var searchResponse = JsonConvert.DeserializeObject<SearchResponse>(json);

            toRet.MgmtShown = searchResponse.mgmtShowing;
            toRet.MgmtCount = searchResponse.mgmtTotal ;
            toRet.PropertyShown = searchResponse.propertiesShowing;
            toRet.PropertyCount = searchResponse.propertiesTotal;

            foreach (var mg in searchResponse.mgmts)
            {
                MgmtResult mr = new MgmtResult();
                mr.Name = mg.name;
                mr.Market = mg.market;
                mr.State = mg.state;
                toRet.Mgmts.Add(mr);
            }

            foreach (var p in searchResponse.properties)
            {
                PropertyResult pr = new PropertyResult();
                pr.Name = p.name;
                if (!String.IsNullOrWhiteSpace(p.formerName) && p.formerName != p.name) 
                    pr.Name+= " (" + p.formerName +")";
                pr.Address = p.streetAddress;
                pr.City = p.city;
                pr.Market = p.market;
                pr.State = p.state;
                toRet.Properties.Add(pr);
            }

            return toRet;
        }
    }
}
