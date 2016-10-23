using System.Web.Mvc;
using Monk.Utils;

namespace Monk.Filters
{
    public class AccessVerifyAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //base.OnAuthorization(filterContext);

            var area = filterContext.RouteData.DataTokens["area"];
            if (filterContext.ActionDescriptor.IsDefined(typeof(AnonymousAttribute), false) || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AnonymousAttribute), false)) { return; }

            if (area != null && area.ToString().ToLower() == "services")
            {
                // 验证授权码是否正确
                var accountId = filterContext.HttpContext.Request.Headers["AccountId"];
                var secretKey = filterContext.HttpContext.Request.Headers["SecretKey"];
                if (accountId != null && secretKey != null)
                {
                    var _secretKey = RESTFul.GetSecretKey(accountId, Keys.Access_Token);
                    if (secretKey != _secretKey) filterContext.Result = notAllow;
                    else return;
                }
                else filterContext.Result = notAllow;
            }
            else
            {
                if (filterContext.HttpContext.Session[Keys.SessionKey] == null)
                {
                    if (filterContext.HttpContext.Request.IsAjaxRequest() || filterContext.HttpContext.Request.Browser.Type.ToLower() == "unknown") filterContext.Result = notAllow;
                    else filterContext.Result = new RedirectResult("~/Backend");
                }
            }
        }

        public static JsonResult notAllow = new JsonResult()
        {
            Data = new JsonData<object>()
            {
                info = "禁止未授权操作",
                status = "not_allow"
            },
            JsonRequestBehavior = JsonRequestBehavior.AllowGet
        };
    }
}