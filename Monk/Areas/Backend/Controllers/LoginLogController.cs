using System;
using System.Web.Mvc;
using Monk.ViewModels;
using Monk.Utils;
using System.Collections.Generic;

namespace Monk.Areas.Backend.Controllers
{
    public class LoginLogController : Controller
    {
        RESTFul restful = new RESTFul(RESTFul.GetSecretKey(Keys.Access_Token));

        [HttpGet]
        public ActionResult Select()
        {
            return View();
        }

        [HttpGet]
        public JsonResult List(int pageSize, int pageIndex = 0, string account = "", string sucessed = null)
        {
            var clientResult = restful.Get<JsonData<List<LoginLogVM>>>(Url.Action("Select", "LoginLog", new { area = "Services" }), new
            {
                pageSize,
                pageIndex,
                account,
                sucessed
            });
            return Json(clientResult, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Detail(Guid id)
        {
            if (id == null) return Content("非法参数");
            var viewModel = new LoginLogVM();
            var clientResult = restful.Get<JsonData<LoginLogVM>>(Url.Action("Detail", "LoginLog", new { area = "Services" }), new { logId = id });
            if (clientResult.status == "y") viewModel = clientResult.data;
            return View(viewModel);
        }

        [HttpPost]
        public JsonResult Delete(string ids)
        {
            var clientResult = restful.Post<JsonData<List<object>>>(Url.Action("Delete", "LoginLog", new { area = "Services" }), new
            {
                ids
            });
            return Json(clientResult);
        }
    }
}