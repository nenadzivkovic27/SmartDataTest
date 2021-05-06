using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.DataTypes
{
    public class Market
    {
        public string market { get; set; }
        public string state { get; set; }

        public override string ToString()
        {
            return state + " - " + market;
        }
    }
}
