using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Monk.Areas.Backend.ViewModels;
using Monk.Utils;
using Monk.ViewModels;

namespace Monk.Areas.Backend.Controllers
{
    public class SysSetController : Controller
    {
        [HttpGet]
        public ActionResult Detail()
        {
            var viewModel = new SysSetViewModel();
            var restful = new RESTFul(RESTFul.GetSecretKey(Keys.Access_Token));
            var clientResult = restful.Get<JsonData<SysSetViewModel>>(Url.Action("Detail", "SysSet", new { area = "Services" }));
            if (clientResult.status == "y") viewModel = clientResult.data;
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Update(Guid? id)
        {
            if (id == null) return Content("非法参数");
            var viewModel = new SysSetViewModel();
            var restful = new RESTFul(RESTFul.GetSecretKey(Keys.Access_Token));
            var clientResult = restful.Get<JsonData<SysSetViewModel>>(Url.Action("Detail", "SysSet", new { area = "Services" }), new { setID = id });
            if (clientResult.status == "y") viewModel = clientResult.data;
            return View(viewModel);
        }

        [HttpPost]
        public JsonResult Update(SysSetViewModel viewModel)
        {
            var restful = new RESTFul(RESTFul.GetSecretKey(Keys.Access_Token));
            var clientResult = restful.Post<JsonData<object>>(Url.Action("Update", "SysSet", new { area = "Services" }), viewModel);
            return Json(clientResult);
        }
    }
}