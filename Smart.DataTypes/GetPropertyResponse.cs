using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.DataTypes
{
    public class GetPropertyResponse : SmartResponseBase
    {
        public GetPropertyResponse()
        {
            Properties = new List<Property>();
        }

        public long PropertiesTotal { get; set; }
        public long PropertiesShowing { get { return Properties.LongCount(); } }
        public List<Property> Properties { get; set; }
    }
}
