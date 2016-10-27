using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Monk.Utils;
using Monk.ViewModels;
using Monk.Areas.Backend.App_Code;

namespace Monk.Areas.Backend.Controllers
{
    public class ModuleController : Controller
    {
        RESTFul restful = new RESTFul(RESTFul.GetSecretKey(Keys.Access_Token));

        [HttpGet]
        public ActionResult Select()
        {
            return View();
        }

        [HttpGet]
        public JsonResult Modules()
        {
            var clientResult = restful.Get<JsonData<List<V_ModuleVM>>>(Url.Action("Modules", "Module", new { area = "Services" }));
            return Json(clientResult, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Insert(Guid? id)
        {
            ViewData["ModuleList"] = Common.ModuleDropDownList(id);
            return View(new ModuleVM() { Enable = true, Iconfont = "icon-backend-file", Sort = 0 });
        }
    }
}