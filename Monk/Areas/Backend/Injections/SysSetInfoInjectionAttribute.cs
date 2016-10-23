using System.Web.Mvc;
using System.Web.Routing;
using SyntacticSugar;
using Monk.Areas.Backend.ViewModels;
using Monk.Models;
using Monk.Utils;

namespace Monk.Areas.Backend.Injections
{
    public class SysSetInfoInjectionAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);

            var area = filterContext.RouteData.DataTokens["area"];
            if (area != null && area.ToString().ToLower() == "backend")
            {
                if (filterContext.HttpContext.Session[Keys.SessionKey] != null)
                {
                    CacheManager<SysSet> cm = CacheManager<SysSet>.GetInstance();
                    if (cm.Get(Keys.SysSetCacheKey) == null)
                    {
                        var sessionModel = SessionHelper.GetSessionInstance<SessionMember>(Keys.SessionKey);
                        var apiUrl = new UrlHelper(new RequestContext(filterContext.HttpContext, filterContext.RouteData)).Action("Detail", "SysSet", new { area = "Services" });
                        RESTFul restful = new RESTFul(RequestInfo.Domain, sessionModel.MemberID.ToString(), RESTFul.GetSecretKey(sessionModel.MemberID.ToString(), Keys.Access_Token));
                        JsonData<SysSet> clientResult = restful.Get<JsonData<SysSet>>(apiUrl);
                        if (clientResult.status == "y")
                        {
                            cm.Add(Keys.SysSetCacheKey, clientResult.data);
                        }
                    }
                    var sysSetModel = cm.Get(Keys.SysSetCacheKey);
                    ActionResult result = filterContext.Result;
                    if (result is ViewResult)
                    {
                        ViewResult vresult = result as ViewResult;
                        vresult.ViewData["SysSetInfo"] = sysSetModel;
                        filterContext.Result = vresult;
                    }
                    else if (result is PartialViewResult)
                    {
                        PartialViewResult presult = result as PartialViewResult;
                        presult.ViewData["SysSetInfo"] = sysSetModel;
                        filterContext.Result = presult;
                    }
                    else
                    {
                    }
                }
            }
        }
    }
}