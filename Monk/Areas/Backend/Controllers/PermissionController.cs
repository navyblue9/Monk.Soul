using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using SqlSugar;
using AutoMapper;
using AutoMapper.Configuration;
using Monk.Models;
using Monk.DbStore;
using Monk.Utils;
using Monk.Filters;
using Monk.Areas.Backend.ViewModels;

namespace Monk.Areas.Backend.Controllers
{
    public class PermissionController : BaseController
    {
        public PermissionController(DbServices services) : base(services) { }

        [HttpGet]
        public ActionResult Group() { return View(); }

        [HttpGet]
        public JsonResult GroupPermission()
        {
            var clientResult = new JsonData<object>();
            var cfg = new MapperConfigurationExpression();
            cfg.CreateMap<V_Module, V_ModuleVM>();
            cfg.CreateMap<V_Havior, V_HaviorVM>();
            cfg.CreateMap<V_Button, V_ButtonVM>();
            services.Command((db) =>
            {
                var modules = db.Queryable<V_Module>().Where(c => true).ToList();
                var haviors = db.Queryable<V_Havior>().Where(c => true).ToList();
                var buttons = db.Queryable<V_Button>().Where(c => true).ToList();
                clientResult.SetClientData("y", "获取成功", new
                {
                    modules = Mapper.Map<List<V_ModuleVM>>(modules),
                    haviors = Mapper.Map<List<V_HaviorVM>>(haviors),
                    buttons = Mapper.Map<List<V_ButtonVM>>(buttons)
                });
            });
            return Json(clientResult, JsonRequestBehavior.AllowGet);
        }
    }
}