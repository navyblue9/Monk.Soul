using System.Web.Mvc;
using Monk.Areas.Backend.ViewModels;
using Monk.Utils;

namespace Monk.Areas.Backend.Injections
{
    public class MemberInfoInjectionAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
            if (filterContext.HttpContext.Session[Keys.SessionKey] != null)
            {
                var result = filterContext.Result;
                if (result is ViewResult)
                {
                    var vresult = result as ViewResult;
                    if (vresult.ViewData[Keys.MemberInfoInjectionKey] == null)
                    {
                        vresult.ViewData[Keys.MemberInfoInjectionKey] = SessionHelper.GetSessionInstance<SessionMemberVM>(Keys.SessionKey);
                    }
                    filterContext.Result = vresult;
                }
                else if (result is PartialViewResult)
                {
                    var presult = result as PartialViewResult;
                    if (presult.ViewData[Keys.MemberInfoInjectionKey] == null)
                    {
                        presult.ViewData[Keys.MemberInfoInjectionKey] = SessionHelper.GetSessionInstance<SessionMemberVM>(Keys.SessionKey);
                    }
                    filterContext.Result = presult;
                }
            }
        }
    }
}