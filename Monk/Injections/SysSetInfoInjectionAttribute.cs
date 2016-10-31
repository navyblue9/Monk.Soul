using System.Linq;
using System.Web.Mvc;
using SqlSugar;
using AutoMapper;
using Monk.Utils;
using Monk.DbStore;
using Monk.Areas.Backend.ViewModels;
using Monk.Models;

namespace Monk.Injections
{
    public class SysSetInfoInjectionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.ActionDescriptor.IsDefined(typeof(ExemptionInjectionAttribute), false) || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(ExemptionInjectionAttribute), false)) { return; }
            var viewModel = new SysSetVM();
            if (!CacheManager.Contains(Keys.SysSetCacheKey))
            {
                using (var services = new DbServices())
                {
                    services.Command((db) =>
                    {
                        Mapper.Initialize(c => c.CreateMap<SysSet, SysSetVM>());
                        viewModel = Mapper.Map<SysSetVM>(db.Queryable<SysSet>().FirstOrDefault());
                    });
                }
                CacheManager.Set(Keys.SysSetCacheKey, viewModel);
            }
            else viewModel = CacheManager.Get<SysSetVM>(Keys.SysSetCacheKey);
            if (filterContext.RouteData.DataTokens[Keys.SysSetInfoInjectionKey] == null)
            {
                filterContext.RouteData.DataTokens.Add(Keys.SysSetInfoInjectionKey, viewModel);
            }
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
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