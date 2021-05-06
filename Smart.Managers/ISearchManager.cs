using Smart.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.Managers
{
    public interface ISearchManager
    {
        public SmartSearchResponse Search(SmartSearchRequest request);
        public GetMarketsResponse GetAllMarkets();
        public GetMgmtResponse GetMgmt(int mgmtID);
        public GetPropertyResponse GetProperty(int propertyID);

    }
}
