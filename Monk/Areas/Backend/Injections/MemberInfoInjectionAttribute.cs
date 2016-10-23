using System.Web.Mvc;
using System.Web.Routing;
using SyntacticSugar;
using Monk.Areas.Backend.ViewModels;
using Monk.Models;
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
                var memberInfo = SessionHelper.GetSessionInstance<SessionMember>(Keys.SessionKey);
                ActionResult result = filterContext.Result;
                if (result is ViewResult)
                {
                    ViewResult vresult = result as ViewResult;
                    vresult.ViewData["MemberInfo"] = memberInfo;
                    filterContext.Result = vresult;
                }
                else if (result is PartialViewResult)
                {
                    PartialViewResult presult = result as PartialViewResult;
                    presult.ViewData["MemberInfo"] = memberInfo;
                    filterContext.Result = presult;
                }
                else
                {
                }
            }
        }
    }
}