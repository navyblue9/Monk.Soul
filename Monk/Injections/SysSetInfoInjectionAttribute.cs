using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Linq;
using Monk.Utils;
using Monk.ViewModels;


namespace Monk.Injections
{
    public class SysSetInfoInjectionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (filterContext.ActionDescriptor.IsDefined(typeof(ExemptionInjectionAttribute), false) || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(ExemptionInjectionAttribute), false)) { return; }
            if (HttpRuntimeCacheHelper.Get<SysSetVM>(Keys.SysSetCacheKey) == null)
            {
                var restful = new RESTFul(RESTFul.GetSecretKey(Keys.Access_Token));
                var clientResult = restful.Get<JsonData<SysSetVM>>(RouteHelper.RouteUrl(new { controller = "SysSet", action = "Detail" }));
                HttpRuntimeCacheHelper.Set(Keys.SysSetCacheKey, clientResult.data);
            }
            if (filterContext.RouteData.DataTokens[Keys.SysSetInfoInjectionKey] == null)
            {
                filterContext.RouteData.DataTokens.Add(Keys.SysSetInfoInjectionKey, HttpRuntimeCacheHelper.Get<SysSetVM>(Keys.SysSetCacheKey));
            }
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
            var result = filterContext.Result;
            if (result is ViewResult)
            {
                var vresult = result as ViewResult;
                if (vresult.ViewData[Keys.SysSetInfoInjectionKey] == null)
                {
                    vresult.ViewData[Keys.SysSetInfoInjectionKey] = filterContext.RouteData.DataTokens[Keys.SysSetInfoInjectionKey] as SysSetVM;
                }
                filterContext.Result = vresult;
            }
            else if (result is PartialViewResult)
            {
                var presult = result as PartialViewResult;
                if (presult.ViewData[Keys.SysSetInfoInjectionKey] == null)
                {
                    presult.ViewData[Keys.SysSetInfoInjectionKey] = filterContext.RouteData.DataTokens[Keys.SysSetInfoInjectionKey] as SysSetVM;
                }
                filterContext.Result = presult;
            }
        }
    }
}