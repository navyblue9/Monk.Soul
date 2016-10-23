using System.Web.Mvc;
using Monk.Filters;
using Monk.Areas.Backend.Injections;

namespace Monk
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            // 注：先进后出
            filters.Add(new SysSetInfoInjectionAttribute());
            filters.Add(new MemberInfoInjectionAttribute());
            filters.Add(new AccessVerifyAttribute());
        }
    }
}