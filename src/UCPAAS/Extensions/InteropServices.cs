using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using UCPAAS.Model;

namespace UCPAAS.Extensions {
    public class InteropServices {
        private readonly string _url;
        public InteropServices(string url) {
            _url = url;
        }

        public async Task<TResult> HttpsPostAsync<T, TResult>(UCPAASSetting _UCPAASSetting, string functionName, T value) {
            using (var httpClient =new HttpClient()) {
                httpClient.BaseAddress = new Uri(_url);
                httpClient.DefaultRequestHeaders.Add("ContentType", "application/json;charset=utf-8");
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", _UCPAASSetting.Authorization);

                var response = await httpClient.PostAsJsonAsync(functionName, value);
                if (response.IsSuccessStatusCode) {
                    return await response.Content.ReadAsAsync<TResult>();
                }
                else {
                    await HandleError(response);
                }

                return default(TResult);
            }
        }


        public async Task<TResult> HttpsGetAsync<TResult>(UCPAASSetting _UCPAASSetting, string functionName) {
            using (var httpClient = new HttpClient()) {
                httpClient.BaseAddress = new Uri(_url);
                httpClient.DefaultRequestHeaders.Add("ContentType", "application/json;charset=utf-8");
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", _UCPAASSetting.Authorization);
                var response = await httpClient.GetAsync(functionName);
                if (response.IsSuccessStatusCode) {
                    return await response.Content.ReadAsAsync<TResult>();
                }
                else {
                    await HandleError(response);
                }

                return default(TResult);
            }
        }



        internal async Task HandleError(HttpResponseMessage response) {
            switch (response.StatusCode) {
                case System.Net.HttpStatusCode.NotFound:
                case System.Net.HttpStatusCode.Forbidden:
                    HandleError(); break;
                case System.Net.HttpStatusCode.BadRequest:
                    var error2 = await response.Content.ReadAsAsync<BadRequest>();
                    throw new Exception(error2.ErrorMessage);
                default:
                    var error = await response.Content.ReadAsStringAsync();
                    HandleError(error); break;
            }

        }

        internal static void HandleError() {
            throw new DependencyException();
        }

        internal static void HandleError(string errorMessage) {
            throw new DependencyException(errorMessage);
        }
    }

    public class BadRequest {
        public string ErrorMessage { get; set; }
    }
}

