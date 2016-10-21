using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SyntacticSugar;
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
            EncryptSugar encrypt = new EncryptSugar();
            RESTFul restful = new RESTFul(RequestInfo.Domain);
            JsonData<Member> clientResult = restful.Post<JsonData<Member>>(Url.Action("Signin", "Member", new { area = "Services" }), new
            {
                account = viewModel.Account.Trim(),
                password = encrypt.MD5(viewModel.Password.Trim()).ToLower()
            });
            if (clientResult.status == "n")
            {
                clientResult.selector = "#Account";
            }
            return Json(clientResult);
        }
    }
}