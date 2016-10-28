using Monk.Areas.Backend.App_Code;
using Monk.Utils;
using Monk.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Monk.Areas.Backend.Controllers
{
    public class HaviorController : Controller
    {
        RESTFul restful = new RESTFul(RESTFul.GetSecretKey(Keys.Access_Token));

        [HttpGet]
        public ActionResult Select()
        {
            return View();
        }

        [HttpGet]
        public JsonResult List(int pageSize, int pageIndex = 0)
        {
            var clientResult = restful.Get<JsonData<List<V_HaviorVM>>>(Url.Action("Select", "Havior", new { area = "Services" }), new
            {
                pageSize,
                pageIndex
            });
            return Json(clientResult, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Insert()
        {
            ViewData["ModuleList"] = Common.ModuleDropDownList();
            return View(new HaviorVM() { Enable = true, Route = true, Index = false });
        }
    }
}