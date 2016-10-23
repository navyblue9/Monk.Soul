using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SyntacticSugar;
using Monk.Areas.Backend.ViewModels;
using Monk.Utils;
using Monk.Models;

namespace Monk.Areas.Backend.Controllers
{
    public class SysSetController : Controller
    {
        SessionMember sessionModel = SessionHelper.GetSessionInstance<SessionMember>(Keys.SessionKey);

        [HttpGet]
        public ActionResult Detail()
        {
            var model = new SysSet();
            var restful = new RESTFul(RequestInfo.Domain, sessionModel.MemberID.ToString(), RESTFul.GetSecretKey(sessionModel.MemberID.ToString(), Keys.Access_Token));
            var clientResult = restful.Get<JsonData<SysSet>>(Url.Action("Detail", "SysSet", new { area = "Services" }));
            if (clientResult.status == "y") model = clientResult.data;
            return View(model);
        }

        [HttpGet]
        public ActionResult Update(Guid? id)
        {
            if (id == null) return Content("非法参数");
            var model = new SysSet();
            var restful = new RESTFul(RequestInfo.Domain, sessionModel.MemberID.ToString(), RESTFul.GetSecretKey(sessionModel.MemberID.ToString(), Keys.Access_Token));
            var clientResult = restful.Get<JsonData<SysSet>>(Url.Action("Detail", "SysSet", new { area = "Services" }), new { setID = id });
            if (clientResult.status == "y") model = clientResult.data;
            return View(model);
        }

        [HttpPost]
        public JsonResult Updata(SysSet model)
        {
            return Json(null);
        }
    }
}