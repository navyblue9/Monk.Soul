﻿using System.Web.Mvc;
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
                var memberInfo = SessionHelper.GetSessionInstance<SessionMemberVM>(Keys.SessionKey);
                var result = filterContext.Result;
                if (result is ViewResult)
                {
                    var vresult = result as ViewResult;
                    vresult.ViewData[Keys.MemberInfoInjectionKey] = memberInfo;
                    filterContext.Result = vresult;
                }
                else if (result is PartialViewResult)
                {
                    var presult = result as PartialViewResult;
                    presult.ViewData[Keys.MemberInfoInjectionKey] = memberInfo;
                    filterContext.Result = presult;
                }
            }
        }
    }
}