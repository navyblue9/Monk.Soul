using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Monk.Injections;
using Monk.Utils;
using Monk.ViewModels;

namespace Monk.Areas.Backend.Injections
{
    public class HaviorInfoInjectionAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
            var _area = filterContext.RouteData.DataTokens["area"];
            if (_area != null && Keys.AccessVerifyAreas.Any(u => u.ToLower() == _area.ToString().ToLower()))
            {
                var _controller = filterContext.RouteData.Values["controller"];
                var _action = filterContext.RouteData.Values["action"];
                var _httpMethod = filterContext.HttpContext.Request.HttpMethod;
                var restful = new RESTFul(RESTFul.GetSecretKey(Keys.Access_Token));
                var clientResult = restful.Get<JsonData<V_HaviorVM>>(RouteHelper.RouteUrl(new { controller = "Havior", action = "HaviorInfo" }), new { _area, _controller, _action, _httpMethod });
                var result = filterContext.Result;
                if (result is ViewResult)
                {
                    var vresult = result as ViewResult;
                    vresult.ViewData[Keys.HaviorInfoInjectionKey] = clientResult.data == null ? new V_HaviorVM() { } : clientResult.data;
                    filterContext.Result = vresult;
                }
                else if (result is PartialViewResult)
                {
                    var presult = result as PartialViewResult;
                    presult.ViewData[Keys.HaviorInfoInjectionKey] = clientResult.data == null ? new V_HaviorVM() { } : clientResult.data;
                    filterContext.Result = presult;
                }
            }
        }
    }
}