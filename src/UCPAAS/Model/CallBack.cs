using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCPAAS.Model {


    public class CallBack : Model {
        public string fromClient { get; set; }

        public string to { get; set; }

        public int maxallowtime { get; set; }

        public string userData { get; set; }
    }

    public class CallBackUCPAAS {
        public CallBack callback { get; set; }
    }

    public class ApplyUCPAAS{
        public Apply client { get; set; }
    }

    public class Apply : Model {
        public string friendlyName { get; set; }
        public string charge { get; set; }
        public string mobile { get; set; }
        public string clientType { get; set; }

    }
}
