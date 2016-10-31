using System;
using System.Web.Mvc;
using Monk.Utils;
using Hangfire;
using Monk.DbStore;
using Monk.Models;
using Monk.Areas.Backend.ViewModels;

namespace Monk.Filters
{
    public class ApplicationErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            Exception ex = filterContext.Exception;

            Exception innerEx = ex.InnerException == null ? ex : ex.InnerException;
            while (innerEx.InnerException != null)
            {
                innerEx = innerEx.InnerException;
            }

            var sessionModel = filterContext.HttpContext.Session[Keys.SessionKey] as MemberSessionVM;
            Guid logMemberId = default(Guid);
            if (sessionModel != null)
            {
                logMemberId = sessionModel.MemberID;
            }

            var logger = new Models.ErrorLog
            {
                LogID = Guid.NewGuid(),
                LogMemberID = logMemberId,
                LogTime = DateTime.Now,
                Message = ex.Message,
                StackTrace = ex.StackTrace,
                Source = ex.Source,
                TargetSite = ex.TargetSite.ToString(),
                HelpLink = ex.HelpLink,
                HResult = ex.HResult.ToString()
            };

            BackgroundJob.Enqueue(() => StartLog(logger));

            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = new JsonResult()
                {
                    Data = new JsonData<object>() { info = "应用程序异常，请联系管理员", status = "n" },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            else
            {
                filterContext.Result = new ContentResult()
                {
                    Content = "应用程序异常，请联系管理员"
                };
            }

            filterContext.ExceptionHandled = true;
            base.OnException(filterContext);
        }

        public void StartLog(ErrorLog logger)
        {
            using (var services = new DbServices())
            {
                services.Command((db) =>
                {
                    db.Insert<ErrorLog>(logger);
                });
            }

            MailHelper.SendTextEmail("百签软件（中山）有限公司，技术支持", "tech@baisoft.org", "百小僧", "monk@baisoft.org", "应用程序异常通知", @"引起异常用户ID：" + logger.LogMemberID + @"

异常消息：" + logger.Message + @"

当前异常应用程序：" + logger.Source + @"

引起异常的方法：" + logger.TargetSite + @"

异常堆栈信息：" + logger.StackTrace + @"

异常编码数字：" + logger.HResult + @"

异常帮助文档：" + logger.HelpLink + @"

异常记录时间：" + logger.LogTime + @"


");
        }
    }
}