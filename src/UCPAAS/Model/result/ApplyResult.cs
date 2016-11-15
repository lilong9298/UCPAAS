using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCPAAS.Model.result {
    public class ApplyClientResult {
        public int balance { get; set; }
        public string clientNumber { get; set; }
        public string clientPwd { get; set; }
        public DateTime createDate { get; set; }
    }

    public class ApplyResult {
       public AppResp resp { get; set; }
    }
    public class AppResp : Resp {
        public ApplyClientResult client { get; set; }
    }
}
