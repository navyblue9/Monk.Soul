using System.Web.Mvc;
using System.Linq;
using Monk.Utils;

namespace Monk.Filters
{
    public class AccessVerifyAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.ActionDescriptor.IsDefined(typeof(AnonymousAttribute), false) || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AnonymousAttribute), false)) { return; }
            var area = filterContext.RouteData.DataTokens["area"];
            if (area != null && Keys.AccessVerifyAreas.Any(u => u.ToLower() == area.ToString().ToLower()))
            {
                if (filterContext.HttpContext.Session[Keys.SessionKey] == null)
                {
                    if (filterContext.HttpContext.Request.IsAjaxRequest() || filterContext.HttpContext.Request.Browser.Type.ToLower() == "unknown") filterContext.Result = notAllow;
                    else filterContext.Result = new RedirectResult("~/Backend");
                }
            }
        }

        private static JsonResult notAllow = new JsonResult()
        {
            Data = new JsonData<object>() { info = "禁止未授权操作", status = "n" },
            JsonRequestBehavior = JsonRequestBehavior.AllowGet
        };
    }
}