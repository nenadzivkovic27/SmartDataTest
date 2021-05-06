using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDemoApp.WebApiClasses
{
    public class SearchRequest
    {
        public string searchTerm { get; set; }
        public Market market { get; set; }
        public int limit { get; set; }
    }
}
