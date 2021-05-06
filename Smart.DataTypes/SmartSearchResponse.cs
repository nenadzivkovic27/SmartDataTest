using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.DataTypes
{
    public class SmartSearchResponse : SmartResponseBase
    {
        public SmartSearchResponse()
        {
            Mgmts = new List<Mgmt>();
            Properties = new List<Property>();
        }

        public long MgmtTotal { get; set; }
        public int MgmtShowing { get { return Mgmts.Count(); } }
        public long PropertiesTotal { get; set; }
        public int PropertiesShowing { get { return Properties.Count(); } }
        public List<Mgmt> Mgmts { get; set; }
        public List<Property> Properties { get; set; }


    }
}
