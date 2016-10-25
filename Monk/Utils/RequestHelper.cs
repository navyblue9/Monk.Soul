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

        public static string UserAddress
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
    }
}