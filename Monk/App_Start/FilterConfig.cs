using System.Web.Mvc;
using Monk.Filters;

namespace Monk
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new AccessVerifyAttribute());
        }
    }
}