using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCPAAS.Model.result
{
    public class CBR
    {
        public string createDate { get; set; }

        public string callId { get; set; }
    }

    public class CallBackResult {
        public CallBackResp resp { get; set; }
    }
    public class CallBackResp : Resp {
        public CBR callback { get; set; }
    }
}
