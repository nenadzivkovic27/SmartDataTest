using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.DataTypes
{
    public class GetMarketsResponse : SmartResponseBase
    {

        public GetMarketsResponse()
        {
            Markets = new List<Market>();
        }

        public long MarketsCount{ get { return Markets.LongCount(); } }
        public List<Market> Markets { get; set; }

    }
}
