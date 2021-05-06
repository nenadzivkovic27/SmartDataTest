using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.DataTypes
{
    public class Property
    {
        public int propertyID { get; set; }
        public string name { get; set; }
        public string formerName { get; set; }
        public string streetAddress { get; set; }
        public string city { get; set; }
        public string market { get; set; }
        public string state { get; set; }
        public float lat { get; set; }
        public float lng { get; set; }

        public override string ToString()
        {
            return name;
        }

        public override bool Equals(object obj)
        {
            if (obj is Property)
            {
                Property op = obj as Property;
                return propertyID == op.propertyID
                    && name.ToLower() == op.name.ToLower()
                    && market.ToLower() == op.market.ToLower()
                    && state.ToLower() == op.state.ToLower();
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(propertyID, name.ToLower(), market.ToLower(), state.ToLower());
        }
    }

    public class PropertyRoot
    {
        public Property property { get; set; }
    }

}
