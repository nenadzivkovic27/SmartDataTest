using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDemoApp.DemoAppDataTypes
{
    public class MgmtResult
    {
        public string Name { get; set; }
        public string Market { get; set; }
        public string State { get; set; }

        public override string ToString()
        {
            return Name + ", " + Market + ", " + State;
        }
    }
}
