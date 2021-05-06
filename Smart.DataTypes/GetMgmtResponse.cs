using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.DataTypes
{
    public class GetMgmtResponse : SmartResponseBase
    {
        public GetMgmtResponse()
        {
            Mgmts = new List<Mgmt>();
        }

        public long MgmtTotal { get; set; }
        public long MgmtShowing { get { return Mgmts.LongCount(); } }
        public List<Mgmt> Mgmts { get; set; }
    }
}
