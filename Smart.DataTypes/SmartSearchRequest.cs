using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.DataTypes
{
    public class SmartSearchRequest
    {

        public string SearchTerm { get; set; }
        public Market Market { get; set; }
        public int Limit { get; set; }

        public SmartSearchRequest ()
        {
            Limit = 25;
        }

    }
}
