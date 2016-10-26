using System;
using System.Linq;
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
        public JsonResult List(int pageSize, int pageIndex = 0)
        {
            var clientResult = restful.Get<JsonData<List<LoginLogViewModel>>>(Url.Action("Select", "LoginLog", new { area = "Services" }), new
            {
                pageSize,
                pageIndex
            });
            return Json(clientResult, JsonRequestBehavior.AllowGet);
        }
    }
}