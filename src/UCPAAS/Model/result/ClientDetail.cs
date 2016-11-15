using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCPAAS.Model.result
{
    public class ClientDetail
    {
        /// <summary>
        ///  必选 Client绑定的昵称
        /// </summary>
        public string friendlyName {get;set;}
        /// <summary>
        ///  必选 Client类型（即平台是否对Client计费）    
        /// </summary>   
        public string clientType {get;set;}
        /// <summary>
        ///   必选 Client绑定的手机号码     
        /// </summary>
        public string mobile { get; set; }
        /// <summary>
        ///   必选 Client余额           
        /// </summary>
        public string balance {get;set;}
        /// <summary>
        ///   必选 Client号码。由14位数字组成
        /// </summary>
        /// </summary>
        public string clientNumber {get;set;}
        /// <summary>
        /// 必选  Client的密码
        /// </summary>
        public string clientPwd   {get;set;}
        /// <summary>
        /// 必选  Client的创建时间  
        /// </summary> 
        public string createDate  {get;set;}
        /// <summary>
        ///    可选  是否开通呼转1：开通，0：未开通
        /// </summary>
        public string roam    {get;set;}            
    }

    public class ClientDetailResult {
        public ClientDetailResp resp { get; set; }
    }
    public class ClientDetailResp : Resp {
        public ClientDetail client { get; set; }
    }
}
