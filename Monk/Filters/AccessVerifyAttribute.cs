using System.Web.Mvc;
using Monk.Utils;
using Monk.Areas.Backend.ViewModels;

namespace Monk.Filters
{
    public class AccessVerifyAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //base.OnAuthorization(filterContext);

            if (filterContext.ActionDescriptor.IsDefined(typeof(AnonymousAttribute), false) || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AnonymousAttribute), false)) { return; }
            if (filterContext.HttpContext.Session[Keys.SessionKey] == null)
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest() || filterContext.HttpContext.Request.Browser.Type.ToLower() == "unknown")
                {
                    filterContext.Result = new JsonResult()
                    {
                        Data = new JsonData<object>()
                        {
                            info = "禁止未授权访问",
                            status = "n"
                        }
                    };
                }
                else
                {
                    filterContext.Result = new RedirectResult("~/Backend");
                }
            }
            else
            {
                var sessionModel = filterContext.HttpContext.Session[Keys.SessionKey] as SessionMember;
                filterContext.RouteData.DataTokens.Add("MemberInfo", sessionModel);
            }
        }
    }
}