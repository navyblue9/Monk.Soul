using System;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.Configuration;
using Monk.ViewModels;
using Monk.Filters;
using Monk.Areas.Backend.ViewModels;
using Monk.Utils;
using System.Collections.Generic;

namespace Monk.Areas.Backend.Controllers
{
    public class DefaultController : Controller
    {
        RESTFul restful = new RESTFul(RESTFul.GetSecretKey(Keys.Access_Token));

        [HttpGet]
        [Anonymous]
        public ActionResult Signin()
        {
            if (Session[Keys.SessionKey] != null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        [Anonymous]
        public JsonResult Signin(SigninModelVM viewModel)
        {
            var clientResult = restful.Post<JsonData<MemberVM>>(Url.Action("Signin", "Member", new { area = "Services" }), new
            {
                account = viewModel.Account.Trim(),
                password = viewModel.Password.Trim()
            });
            if (clientResult.status == "y")
            {
                var cfg = new MapperConfigurationExpression();
                cfg.CreateMap<MemberVM, SessionMemberVM>();
                cfg.CreateMap<JsonData<MemberVM>, JsonData<SessionMemberVM>>();
                Mapper.Initialize(cfg);
                var clientResultDto = Mapper.Map<JsonData<SessionMemberVM>>(clientResult);

                clientResultDto.data.LogID = Guid.Parse(clientResultDto.others.ToString());
                Session[Keys.SessionKey] = clientResultDto.data;

                return Json(clientResultDto);
            }
            else
            {
                clientResult.selector = "#Account";
            }
            return Json(clientResult);
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Console()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Signout()
        {
            var sessionModel = SessionHelper.GetSessionInstance<SessionMemberVM>(Keys.SessionKey);
            var clientResult = restful.Post<JsonData<object>>(Url.Action("Signout", "Member", new { area = "Services" }), new
            {
                logid = sessionModel.LogID
            });
            if (clientResult.status == "y")
            {
                Session[Keys.SessionKey] = null;
            }
            return Json(clientResult);
        }
    }
}