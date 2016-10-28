using Monk.Areas.Backend.App_Code;
using Monk.Areas.Backend.ViewModels;
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
            return View(new HaviorVM() { Enable = true, Route = true, Index = false, Area = "Backend" });
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Insert(HaviorVM viewModel)
        {
            var sessionModel = Session[Keys.SessionKey] as SessionMemberVM;
            viewModel.LogMemberID = sessionModel.MemberID;
            if (viewModel.Route == true)
            {
                viewModel.Url = Url.Action(viewModel.Action, viewModel.Controller, new { area = viewModel.Area, id = viewModel.Parameter });
            }

            var clientResult = restful.Post<JsonData<object>>(Url.Action("Insert", "Havior", new { area = "Services" }), viewModel);
            return Json(clientResult);
        }

        [HttpGet]
        public ActionResult Detail(Guid? id)
        {
            if (id == null) return Content("非法参数");
            var viewModel = new V_HaviorVM();
            var clientResult = restful.Get<JsonData<V_HaviorVM>>(Url.Action("Detail", "Havior", new { area = "Services" }), new
            {
                haviorId = id
            });
            if (clientResult.status == "y") viewModel = clientResult.data;
            return View(viewModel);
        }
    }
}