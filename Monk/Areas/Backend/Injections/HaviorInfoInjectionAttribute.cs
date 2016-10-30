using System.Linq;
using System.Web.Mvc;
using SqlSugar;
using AutoMapper;
using Monk.Utils;
using Monk.DbStore;
using Monk.Areas.Backend.ViewModels;
using Monk.Models;

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
                var _controller = filterContext.RouteData.Values["controller"].ToString();
                var _action = filterContext.RouteData.Values["action"].ToString();
                var _httpMethod = filterContext.HttpContext.Request.HttpMethod;

                var services = new DbServices();
                var viewModel = new V_HaviorVM();
                services.Command((db) =>
                {
                    Mapper.Initialize(c => c.CreateMap<V_Havior, V_HaviorVM>());
                    viewModel = Mapper.Map<V_HaviorVM>(db.Queryable<V_Havior>().SingleOrDefault(u => u.Area == _area.ToString() && u.Controller == _controller.ToLower() && u.Action == _action.ToLower() && u.HttpMethod == _httpMethod.ToUpper()));
                });

                var result = filterContext.Result;
                if (result is ViewResult)
                {
                    var vresult = result as ViewResult;
                    vresult.ViewData[Keys.HaviorInfoInjectionKey] = viewModel == null ? new V_HaviorVM() : viewModel;
                    filterContext.Result = vresult;
                }
                else if (result is PartialViewResult)
                {
                    var presult = result as PartialViewResult;
                    presult.ViewData[Keys.HaviorInfoInjectionKey] = viewModel == null ? new V_HaviorVM() : viewModel;
                    filterContext.Result = presult;
                }
            }
        }
    }
}