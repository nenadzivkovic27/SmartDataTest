using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDemoApp.DemoAppDataTypes
{
    public class SearchResult
    {
        public long MgmtCount { get; set; }
        public long PropertyCount { get; set; }
        public int MgmtShown { get; set; }
        public int PropertyShown { get; set; }
        public List<MgmtResult> Mgmts { get; set; }
        public List<PropertyResult> Properties { get; set; }

        public SearchResult()
        {
            Mgmts = new List<MgmtResult>();
            Properties = new List<PropertyResult>();
        }

    }
}
