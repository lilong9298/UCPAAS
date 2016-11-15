using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCPAAS.Model;
using UCPAAS.Model.result;

namespace UCPAAS {
    public interface IUCPAASManager {
        /// <summary>
        /// 申请客户端账户
        /// </summary>
        /// <returns></returns>
        Task<ApplyResult> ApplyClientAsync(string functionNumber, ApplyUCPAAS model);

        ///// <summary>
        ///// 获取客户端账号详情
        ///// </summary>
        ///// <returns></returns>
        Task<ClientDetailResult> ClientDetailAsync(string functionNumber, string phone);

        /// <summary>
        /// 回拨
        /// </summary>
        /// <returns></returns>
        Task<CallBackResult> CallBackAsync(string functionNumber, CallBackUCPAAS model);

        ///// <summary>
        ///// 申请双向号码绑定
        ///// </summary>
        ///// <returns></returns>
        //Task AllocNumberAsync();
    }
}
