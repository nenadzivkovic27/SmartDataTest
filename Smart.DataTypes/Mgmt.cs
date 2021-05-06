using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.DataTypes
{
    public class Mgmt
    {
        public int mgmtID { get; set; }
        public string name { get; set; }
        public string market { get; set; }
        public string state { get; set; }

        public override string ToString()
        {
            return name;
        }

        public override bool Equals(object obj)
        {
            if (obj is Mgmt)
            {
                Mgmt om = (Mgmt)obj;
                return mgmtID == om.mgmtID
                    && market.ToLower() == om.market.ToLower()
                    && state.ToLower() == om.state.ToLower();
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(mgmtID, name.ToLower(), market.ToLower(), state.ToLower());
        }
    }

    public class MgmtRoot
    {
        public Mgmt mgmt { get; set; }
    }





}
