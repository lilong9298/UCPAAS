using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCPAAS.Model;

namespace UCPAAS.Test {
    public class DataProvider : IDataProvider {
        public string AccountSid() {
            return "97ca53bee676c2aa8f254d23296ebf20";
        }

        public string AuthToken() {
            return "0c9ff991b503bfa85aef4af606326b55";
        }
        public string AppId() {
            return "2a2c07ae4618411a920e9e609ff676a0";
        }

        public Function GetFunctionModel(string number) {
            switch (number) {
                case "Apply":
                    return new Function() { Url = "https://api.ucpaas.com/", Name = "2014-06-30/Accounts/{0}/Clients?sig={1}" };
                case "FindClient":
                    return new Function() { Url = "https://api.ucpaas.com/", Name = "2014-06-30/Accounts/{0}/ClientsByMobile?sig={1}&mobile={2}&appId={3}" };
                case "CallBack":
                    return new Function() { Url = "https://api.ucpaas.com/", Name = "2014-06-30/Accounts/{0}/Calls/callBack?sig={1}" };

                default:
                    return new Function() { Url = "https://api.ucpaas.com/", Name = "2014-06-30/Accounts/{0}/ClientsByMobile?sig={1}" };
            }
        }
    }
}
