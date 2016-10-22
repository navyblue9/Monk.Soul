using System;
using System.Web.Mvc;
using SyntacticSugar;
using AutoMapper;
using AutoMapper.Configuration;
using Monk.Models;
using Monk.Filters;
using Monk.Areas.Backend.ViewModels;
using Monk.Utils;


namespace Monk.Areas.Backend.Controllers
{
    public class DefaultController : Controller
    {
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
        public JsonResult Signin(SigninModel viewModel)
        {
            RESTFul restful = new RESTFul(RequestInfo.Domain);
            JsonData<Member> clientResult = restful.Post<JsonData<Member>>(Url.Action("Signin", "Member", new { area = "Services" }), new
            {
                account = viewModel.Account.Trim(),
                password = viewModel.Password.Trim()
            });
            if (clientResult.status == "y")
            {
                var cfg = new MapperConfigurationExpression();
                cfg.CreateMap<Member, SessionMember>();
                cfg.CreateMap<JsonData<Member>, JsonData<SessionMember>>();
                Mapper.Initialize(cfg);
                var clientResultDto = Mapper.Map<JsonData<SessionMember>>(clientResult);

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
    }
}