using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.Configuration;
using SqlSugar;
using Monk.DbStore;
using Monk.Models;
using Monk.ViewModels;
using Monk.Utils;
using System.Collections.Generic;
using Monk.Areas.Backend.ViewModels;

namespace Monk.Areas.Backend.Controllers
{
    public class LoginLogController : Controller
    {
        [HttpGet]
        public ActionResult Select()
        {
            var restful = new RESTFul(RESTFul.GetSecretKey(Keys.Access_Token));
            var clientResult = restful.Get<JsonData<int>>(Url.Action("Total", "LoginLog", new { area = "Services" }));
            return View();
        }

        [HttpPost]
        public JsonResult Select(int? pageSize, int? pageNumber = 0, string whereString = "", object whereObj = null)
        {
            var setVewModel = RouteData.DataTokens[Keys.SysSetInfoInjectionKey] as SysSetViewModel;
            pageSize = pageSize == null ? setVewModel.PageSize : pageSize;

            var restful = new RESTFul(RESTFul.GetSecretKey(Keys.Access_Token));
            var clientResult = restful.Get<JsonData<List<LoginLogViewModel>>>(Url.Action("Select", "LoginLog", new { area = "Services" }), new { pageSize, pageNumber, whereString, whereObj });
            return Json(clientResult, JsonRequestBehavior.AllowGet);
        }
    }
}