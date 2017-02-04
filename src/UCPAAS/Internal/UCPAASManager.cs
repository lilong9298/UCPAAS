using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCPAAS.Extensions;
using UCPAAS.Model;
using UCPAAS.Model.result;

namespace UCPAAS.Internal {
    public class UCPAASManager : IUCPAASManager {
        private readonly IDataProvider _dataProvider;
        private readonly Guid _callId;
        public UCPAASManager(IDataProvider dataProvider) {
            _dataProvider = dataProvider;
            _callId = Guid.NewGuid();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="functionNumber"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ApplyResult> ApplyClientAsync(string functionNumber, ApplyUCPAAS model) {
            model.client.appId = _dataProvider.AppId();
            var ucpaasSetting = new UCPAASSetting(_dataProvider.AccountSid(), _dataProvider.AuthToken());
            var functionmodel = _dataProvider.GetFunctionModel(functionNumber);
            var interopServices = new InteropServices(functionmodel.Url);
            var functionname = string.Format(functionmodel.Name, ucpaasSetting.AccountSid, ucpaasSetting.SigParameterValue);
            await _dataProvider.SaveRequest(functionname, _callId);
            var result = await interopServices.HttpsPostAsync<ApplyUCPAAS, ApplyResult>(ucpaasSetting, functionname, model);
            await _dataProvider.SaveResponse(result, _callId);
            return result;
        }

        public async Task<CallBackResult> CallBackAsync(string functionNumber, CallBackUCPAAS model) {
            model.callback.appId = _dataProvider.AppId();
            var ucpaasSetting = new UCPAASSetting(_dataProvider.AccountSid(), _dataProvider.AuthToken());
            var functionmodel = _dataProvider.GetFunctionModel(functionNumber);
            var interopServices = new InteropServices(functionmodel.Url);
            var functionname = string.Format(functionmodel.Name, ucpaasSetting.AccountSid, ucpaasSetting.SigParameterValue);
            await _dataProvider.SaveRequest(model, _callId);
            var result = await interopServices.HttpsPostAsync<CallBackUCPAAS, CallBackResult>(ucpaasSetting, functionname, model);
            await _dataProvider.SaveResponse(result, _callId);
            return result;
        }


        public async Task<ClientDetailResult> ClientDetailAsync(string functionNumber, string phone) {
            var ucpaasSetting = new UCPAASSetting(_dataProvider.AccountSid(), _dataProvider.AuthToken());
            var functionmodel = _dataProvider.GetFunctionModel(functionNumber);
            var interopServices = new InteropServices(functionmodel.Url);
            var functionname = string.Format(functionmodel.Name, ucpaasSetting.AccountSid, ucpaasSetting.SigParameterValue, phone, _dataProvider.AppId());
            await _dataProvider.SaveRequest(functionname, _callId);
            var result = await interopServices.HttpsGetAsync<ClientDetailResult>(ucpaasSetting, functionname);
            await _dataProvider.SaveResponse(result, _callId);

            return result;
        }

    }
}
