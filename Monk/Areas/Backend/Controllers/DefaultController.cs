using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SyntacticSugar;
using AutoMapper;
using AutoMapper.Configuration;
using Monk.Models;
using Monk.Areas.Backend.ViewModels;
using Monk.Utils;


namespace Monk.Areas.Backend.Controllers
{
    public class DefaultController : Controller
    {
        [HttpGet]
        public ActionResult Signin()
        {
            return View();
        }

        [HttpPost]
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
    }
}