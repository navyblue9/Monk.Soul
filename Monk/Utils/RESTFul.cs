using System.Web;
using RestSharp;

namespace Monk.Utils
{
    public class RESTFul
    {
        public string BaseUrl { get; set; }

        public RESTFul() { }

        readonly string _secretKey;

        public RESTFul(string secretKey)
        {
            this.BaseUrl = RequestHelper.Host;
            _secretKey = secretKey;
        }

        public static string GetSecretKey(string access_token)
        {
            var _tokenKey = (access_token + "_Monk.Soul").ToMD5();
            var _secretKey = string.Empty;
            for (int i = 0; i < _tokenKey.Length; i++)
            {
                if (i % 2 == 0) _secretKey += _tokenKey[i].ToString().ToUpper();
                else _secretKey += _tokenKey[i].ToString().ToLower();
            }
            return _secretKey.ToMD5();
        }

        public T Get<T>(string resource, object parameter = null) where T : new()
        {
            return HttpExecute<T>(resource, parameter, Method.GET);
        }

        public T Post<T>(string resource, object parameter = null) where T : new()
        {
            return HttpExecute<T>(resource, parameter, Method.POST);
        }

        public T Delete<T>(string resource, object parameter = null) where T : new()
        {
            return HttpExecute<T>(resource, parameter, Method.DELETE);
        }

        public T Put<T>(string resource, object parameter = null) where T : new()
        {
            return HttpExecute<T>(resource, parameter, Method.PUT);
        }

        public T HttpExecute<T>(string resource, object parameter, Method method) where T : new()
        {
            var request = new RestRequest(resource, method);
            if (parameter != null) request.AddObject(parameter);
            return Execute<T>(request);
        }

        public RestRequest Request(string resource, Method method)
        {
            return new RestRequest(resource, method);
        }

        public string Execute(RestRequest request)
        {
            var client = new RestClient(this.BaseUrl);
            if (_secretKey != null)
            {
                request.AddHeader("SecretKey", _secretKey);
            }
            var response = client.Execute(request);
            if (response.ErrorException != null)
            {
                const string message = "错误检索响应。检查更多信息的内部细节。";
                var httpException = new HttpException(message, response.ErrorException);
                throw httpException;
            }
            return response.Content;
        }

        public T Execute<T>(RestRequest request) where T : new()
        {
            var client = new RestClient(this.BaseUrl);
            if (_secretKey != null)
            {
                request.AddHeader("SecretKey", _secretKey);
            }
            request.AddHeader("LoopBack", "true");
            request.AddHeader("IPAddress", RequestHelper.IPAddress);
            request.AddHeader("HttpMethod", RequestHelper.HttpMethod);
            request.AddHeader("AjaxRequest", RequestHelper.AjaxRequest.ToString());
            request.AddHeader("MobileDevice", RequestHelper.MobileDevice.ToString());
            request.AddHeader("Platform", RequestHelper.Platform);
            request.AddHeader("BrowserType", RequestHelper.BrowserType);
            var response = client.Execute<T>(request);
            if (response.ErrorException != null)
            {
                const string message = "错误检索响应。检查更多信息的内部细节。";
                var httpException = new HttpException(message, response.ErrorException);
                throw httpException;
            }
            return response.Data;
        }
    }
}