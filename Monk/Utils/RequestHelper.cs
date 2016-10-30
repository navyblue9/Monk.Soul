using System.Web;

namespace Monk.Utils
{
    public class RequestHelper
    {
        public static string Domain
        {
            get
            {
                if (((HttpContext.Current.Request.ServerVariables["SERVER_PORT"] == null) || (HttpContext.Current.Request.ServerVariables["SERVER_PORT"] == "")) || (HttpContext.Current.Request.ServerVariables["SERVER_PORT"] == "80"))
                {
                    return HttpContext.Current.Request.ServerVariables["SERVER_NAME"];
                }
                return (HttpContext.Current.Request.ServerVariables["SERVER_NAME"] + ":" + HttpContext.Current.Request.ServerVariables["SERVER_PORT"]);
            }
        }
        public static string Http
        {
            get
            {
                if (HttpContext.Current.Request.ServerVariables["HTTPS"].ToLower() == "on")
                {
                    return "https://";
                }
                return "http://";
            }
        }

        public static string Host
        {
            get
            {
                return Http + Domain;
            }
        }

        public static string IPAddress
        {
            get
            {
                if ((HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] == null) || (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] == ""))
                {
                    return HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                }
                return HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            }
        }

        public static string HttpMethod
        {
            get
            {
                return HttpContext.Current.Request.HttpMethod;
            }
        }
        public static bool AjaxRequest
        {
            get
            {
                var request = HttpContext.Current.Request;
                return ((request["X-Requested-With"] == "XMLHttpRequest") || ((request.Headers != null) && (request.Headers["X-Requested-With"] == "XMLHttpRequest")));
            }
        }

        public static bool MobileDevice
        {
            get
            {
                var request = HttpContext.Current.Request;
                return request.Browser.IsMobileDevice;
            }
        }

        public static string Platform
        {
            get
            {
                var request = HttpContext.Current.Request;
                return request.Browser.Platform;
            }
        }

        public static string Browser
        {
            get
            {
                var request = HttpContext.Current.Request;
                return request.Browser.ToString();
            }
        }
    }
}