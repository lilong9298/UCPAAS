using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCPAAS.Model;

namespace UCPAAS {
    public interface IDataProvider {
        Function GetFunctionModel(string number);

        Task SaveRequest(object model, Guid callid);

        Task SaveResponse(object model, Guid callid);

        string AppId();

        string AuthToken();

        string AccountSid();
    }
}
