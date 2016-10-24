using System.Web.Mvc;
using System.Web.Routing;
using SyntacticSugar;
using Monk.Areas.Backend.ViewModels;
using Monk.ViewModels;
using Monk.Utils;

namespace Monk.Areas.Backend.Injections
{
    public class SysSetInfoInjectionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (filterContext.HttpContext.Session[Keys.SessionKey] != null)
            {
                var cm = CacheManager<SysSetViewModel>.GetInstance();
                if (cm.Get(Keys.SysSetCacheKey) == null)
                {
                    var sessionModel = SessionHelper.GetSessionInstance<SessionMember>(Keys.SessionKey);
                    var apiUrl = new UrlHelper(new RequestContext(filterContext.HttpContext, filterContext.RouteData)).Action("Detail", "SysSet", new { area = "Services" });
                    var restful = new RESTFul(RequestInfo.Domain, sessionModel.MemberID.ToString(), RESTFul.GetSecretKey(sessionModel.MemberID.ToString(), Keys.Access_Token));
                    var clientResult = restful.Get<JsonData<SysSetViewModel>>(apiUrl);
                    if (clientResult.status == "y") cm.Add(Keys.SysSetCacheKey, clientResult.data);
                }
                filterContext.RouteData.DataTokens.Add("SysSetInfo", cm.Get(Keys.SysSetCacheKey));
            }
        }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);

            if (filterContext.HttpContext.Session[Keys.SessionKey] != null)
            {
                var sysSetModel = filterContext.RouteData.DataTokens["SysSetInfo"] as SysSetViewModel;
                var result = filterContext.Result;
                if (result is ViewResult)
                {
                    var vresult = result as ViewResult;
                    vresult.ViewData["SysSetInfo"] = sysSetModel;
                    filterContext.Result = vresult;
                }
                else if (result is PartialViewResult)
                {
                    var presult = result as PartialViewResult;
                    presult.ViewData["SysSetInfo"] = sysSetModel;
                    filterContext.Result = presult;
                }
            }
        }
    }
}