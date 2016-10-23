using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SyntacticSugar;
using Monk.Areas.Backend.ViewModels;
using Monk.Utils;
using Monk.ViewModels;

namespace Monk.Areas.Backend.Controllers
{
    public class SysSetController : Controller
    {
        SessionMember sessionModel = SessionHelper.GetSessionInstance<SessionMember>(Keys.SessionKey);

        [HttpGet]
        public ActionResult Detail()
        {
            var viewModel = new SysSetViewModel();
            var restful = new RESTFul(RequestInfo.Domain, sessionModel.MemberID.ToString(), RESTFul.GetSecretKey(sessionModel.MemberID.ToString(), Keys.Access_Token));
            var clientResult = restful.Get<JsonData<SysSetViewModel>>(Url.Action("Detail", "SysSet", new { area = "Services" }));
            if (clientResult.status == "y") viewModel = clientResult.data;
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Update(Guid? id)
        {
            if (id == null) return Content("非法参数");
            var viewModel = new SysSetViewModel();
            var restful = new RESTFul(RequestInfo.Domain, sessionModel.MemberID.ToString(), RESTFul.GetSecretKey(sessionModel.MemberID.ToString(), Keys.Access_Token));
            var clientResult = restful.Get<JsonData<SysSetViewModel>>(Url.Action("Detail", "SysSet", new { area = "Services" }), new { setID = id });
            if (clientResult.status == "y") viewModel = clientResult.data;
            return View(viewModel);
        }

        [HttpPost]
        public JsonResult Updata(SysSetViewModel viewModel)
        {
            return Json(null);
        }
    }
}