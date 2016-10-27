using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using SqlSugar;
using Monk.DbStore;
using Monk.Models;
using Monk.ViewModels;
using Monk.Utils;
using System.Collections.Generic;
namespace Monk.Areas.Services.Controllers
{
    public class ModuleController : BaseController
    {
        public ModuleController(DbServices services) : base(services) { }

        [HttpGet]
        public JsonResult Modules()
        {
            var clientResult = new JsonData<List<V_ModuleVM>>();
            var cache = HttpRuntimeCacheHelper.Get<List<V_ModuleVM>>("Module_CacheKey");
            if (cache == null)
            {
                services.Command((db) =>
                {
                    Mapper.Initialize(u => u.CreateMap<V_Module, V_ModuleVM>());
                    var list = Mapper.Map<List<V_ModuleVM>>(db.Queryable<V_Module>().Where(c => true).ToList());
                    HttpRuntimeCacheHelper.Set("Module_CacheKey", list);
                    clientResult.SetClientData("y", "获取成功", list);
                });
            }
            else clientResult.SetClientData("y", "获取成功", cache);
            return Json(clientResult, JsonRequestBehavior.AllowGet);
        }
    }
}