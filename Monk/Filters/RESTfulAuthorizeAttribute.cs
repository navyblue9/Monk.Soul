using System.Web.Mvc;
using Monk.Utils;
using System.Linq;

namespace Monk.Filters
{
    public class RESTfulAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.ActionDescriptor.IsDefined(typeof(AnonymousAttribute), false) || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AnonymousAttribute), false)) { return; }
            var area = filterContext.RouteData.DataTokens["area"];
            if (area != null && Keys.RESTfulAuthorizeAreas.Any(u => u.ToLower() == area.ToString().ToLower()))
            {
                var secretKey = filterContext.HttpContext.Request.Headers["SecretKey"];
                if (secretKey != null)
                {
                    var _secretKey = RESTFul.GetSecretKey(Keys.Access_Token);
                    if (secretKey != _secretKey) filterContext.Result = notAllow;
                    else return;
                }
                else filterContext.Result = notAllow;
            }
        }

        private static JsonResult notAllow = new JsonResult()
        {
            Data = new JsonData<object>() { info = "禁止未授权操作", status = "n" },
            JsonRequestBehavior = JsonRequestBehavior.AllowGet
        };
    }
}