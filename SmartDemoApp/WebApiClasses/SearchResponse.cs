using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDemoApp.WebApiClasses
{
    public class SearchResponse
    {
        public bool success { get; set; }
        public string errorMessage { get; set; }
        public long mgmtTotal { get; set; }
        public int mgmtShowing { get; set; }
        public long propertiesTotal { get; set; }
        public int propertiesShowing { get; set; }
        public List<Mgmt> mgmts { get; set; }
        public List<Property> properties { get; set; }
    }
}
