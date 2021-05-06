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
        public long MgmtShowing { get { return Mgmts.LongCount(); } }
        public long PropertiesTotal { get; set; }
        public long PropertiesShowing { get { return Properties.LongCount(); } }
        public List<Mgmt> Mgmts { get; set; }
        public List<Property> Properties { get; set; }


    }
}
