using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using SqlSugar;
using AutoMapper;
using Monk.Models;
using Monk.DbStore;
using Monk.Utils;
using Monk.Filters;
using Monk.Areas.Backend.ViewModels;

namespace Monk.Areas.Backend.Controllers
{
    public class DefaultController : BaseController
    {
        public DefaultController(DbServices services) : base(services) { }

        [HttpGet]
        [Anonymous]
        public ActionResult Signin()
        {
            if (Session[Keys.SessionKey] != null) return RedirectToAction("Index");
            return View();
        }

        [HttpGet]
        public ActionResult Index() { return View(); }

        [HttpGet]
        public JsonResult Menus()
        {
            var clientResult = new JsonData<List<MenuVM>>() { };
            var cache = HttpRuntimeCacheHelper.Get<List<MenuVM>>(Keys.BackendMenus);
            if (cache == null)
            {
                services.Command((db) =>
                {
                    var modules = db.Queryable<V_Module>().Where(c => c.Enable == true).ToList();
                    Mapper.Initialize(c => c.CreateMap<V_Module, MenuVM>());
                    var menus = Mapper.Map<List<MenuVM>>(modules);
                    HttpRuntimeCacheHelper.Set(Keys.BackendMenus, menus);
                    clientResult.SetClientData("y", "获取成功", Mapper.Map<List<MenuVM>>(menus));
                });
            }
            else clientResult.SetClientData("y", "获取成功", cache);
            return Json(clientResult, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Console() { return View(); }
    }
}