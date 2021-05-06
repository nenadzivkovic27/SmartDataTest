using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDemoApp.WebApiClasses
{
    public class MarketResponse
    {
        public int marketsCount { get; set; }
        public List<Market> markets { get; set; }
        public bool success { get; set; }
        public object errorMessage { get; set; }
    }
}
