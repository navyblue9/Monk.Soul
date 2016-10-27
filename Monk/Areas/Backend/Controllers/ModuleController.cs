using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Monk.Utils;
using Monk.ViewModels;
using Monk.Areas.Backend.App_Code;
using Monk.Areas.Backend.ViewModels;
using AutoMapper;

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

        [HttpPost]
        public JsonResult Insert(ModuleVM viewModel)
        {
            var sessionModel = Session[Keys.SessionKey] as SessionMemberVM;
            viewModel.LogMemberID = sessionModel.MemberID;
            var clientResult = restful.Post<JsonData<object>>(Url.Action("Insert", "Module", new { area = "Services" }), viewModel);
            return Json(clientResult);
        }

        [HttpGet]
        public ActionResult Detail(Guid? id)
        {
            if (id == null) return Content("非法参数");
            var viewModel = new V_ModuleVM();
            var clientResult = restful.Get<JsonData<V_ModuleVM>>(Url.Action("Detail", "Module", new { area = "Services" }), new
            {
                moduleId = id
            });
            if (clientResult.status == "y") viewModel = clientResult.data;
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Update(Guid? id)
        {
            if (id == null) return Content("非法参数");
            var viewModel = new ModuleVM();
            var clientResult = restful.Get<JsonData<V_ModuleVM>>(Url.Action("Detail", "Module", new { area = "Services" }), new
            {
                moduleId = id
            });
            if (clientResult.status == "y")
            {
                Mapper.Initialize(c => c.CreateMap<V_ModuleVM, ModuleVM>());
                viewModel = Mapper.Map<ModuleVM>(clientResult.data);
            };
            ViewData["ModuleList"] = Common.ModuleDropDownList(viewModel.ParentID);
            return View(viewModel);
        }

        [HttpPost]
        public JsonResult Update(ModuleVM viewModel)
        {
            var clientResult = restful.Post<JsonData<object>>(Url.Action("Update", "Module", new { area = "Services" }), viewModel);
            return Json(clientResult);
        }
    }
}