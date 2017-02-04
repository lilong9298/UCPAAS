using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCPAAS.Model {
    public class UCPAASOptions {
        public string AppId { get; set; }

        public string AuthToken { get; set; }

        public string AccountSid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FromSerNum { get; set; }

        /// <summary>
        /// 铃声ID
        /// </summary>
        public string RingtoneID { get; set; }
    }
}
