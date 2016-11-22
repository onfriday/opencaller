using Newtonsoft.Json;
using OpenCaller.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OpenCaller.Mobile.BackendClients
{
    sealed class BackendHttpClient
    {
        private static Lazy<BackendHttpClient> _Lazy = new Lazy<BackendHttpClient>(() => new BackendHttpClient());

        public static BackendHttpClient Current { get { return _Lazy.Value; } }

        private BackendHttpClient()
        {
            this._HttpClient = new HttpClient();
            this._HttpClient.BaseAddress = new Uri(@"http://vetnanet-dev-backend.azurewebsites.net");
        }

        private readonly HttpClient _HttpClient;

        internal async Task<ServiceResult> Autenticar(string pUsuario, string pSenha)
        {
            var _serviceResult = new ServiceResult();

            try
            {
                var _args = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("username", pUsuario),
                    new KeyValuePair<string, string>("password", pSenha),
                });

                using (var _response = await this._HttpClient.PostAsync("/token", _args))
                {
                    if (!_response.IsSuccessStatusCode)
                        throw new InvalidOperationException();

                    var _responseContent = await _response.Content.ReadAsStringAsync();

                    if (string.IsNullOrWhiteSpace(_responseContent))
                        throw new InvalidOperationException();

                    var _token = JsonConvert.DeserializeObject<TokenResult>(_responseContent);

                    this._HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_token.token_type, _token.access_token);
                }
            }
            catch (Exception ex) { _serviceResult.AddException(ex); }

            return _serviceResult;
        }

        class TokenResult
        {
            public string access_token { get; set; }
            public string token_type { get; set; }
            public string expires_in { get; set; }
            public string userName { get; set; }
            public DateTime issued { get; set; }
            public DateTime expires { get; set; }
        }

        internal async Task<TResult> PostAsync<TResult>(string pRequestUri, HttpContent pContent)
        {
            using (var _response = await this._HttpClient.PostAsync(pRequestUri.StartsWith("/") ? pRequestUri : $"/{pRequestUri}", pContent))
            {
                if (!_response.IsSuccessStatusCode)
                    throw new InvalidOperationException();

                var _responseContent = await _response.Content.ReadAsStringAsync();

                if (string.IsNullOrWhiteSpace(_responseContent))
                    throw new InvalidOperationException();

                return JsonConvert.DeserializeObject<TResult>(_responseContent);
            }
        }

        internal async Task<TResult> GetAsync<TResult>(string pRequestUri)
        {
            using (var _response = await this._HttpClient.GetAsync(pRequestUri.StartsWith("/") ? pRequestUri : $"/{pRequestUri}"))
            {
                if (!_response.IsSuccessStatusCode)
                    throw new InvalidOperationException();

                var _responseContent = await _response.Content.ReadAsStringAsync();

                if (string.IsNullOrWhiteSpace(_responseContent))
                    throw new InvalidOperationException();

                return JsonConvert.DeserializeObject<TResult>(_responseContent);
            }
        }
    }
}
