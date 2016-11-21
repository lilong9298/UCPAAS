using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UCPAAS.Model
{
    public class UCPAASSetting
    {
        public UCPAASSetting(string accountsid,string authtoken) {
            AccountSid = accountsid;
            AuthToken = authtoken;
            timestap = DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        private static string GetAuthorization(string accountSid, string timestap) {
            //build Authorization
            string Authorization = accountSid + ":" + timestap;
          
            byte[] AuthorizationBytes = Encoding.UTF8.GetBytes(Authorization);
            string AuthorizationBase64 = Convert.ToBase64String(AuthorizationBytes);
            return AuthorizationBase64;
        }

        private static string SigParameter(string accountSid, string Token, string timestap) {
            //build SigParametert
            string str = accountSid + Token + timestap;
            MD5 md5 = MD5.Create();
            byte[] output = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            StringBuilder sBuilder = new StringBuilder();
         
            for (int i = 0; i < output.Length; i++) {
                sBuilder.Append(output[i].ToString("X2"));
            }
            
            return sBuilder.ToString();
        }


        public string timestap { get; }

        public string AccountSid { get;}

        public string AuthToken { get; }

        public string Authorization=> GetAuthorization(AccountSid, timestap);

        public string SigParameterValue => SigParameter(AccountSid, AuthToken, timestap);

      
        
    }
}
