using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using RestSharp;
using SyntacticSugar;
using Monk.Models;
using Monk.Utils;

namespace Monk.Areas.Backend.Controllers
{
    public class AuthorizeController : Controller
    {
        public ActionResult Index()
        {
            RESTFul restful = new RESTFul(RequestInfo.Domain);
            var obj = restful.Post<object>(Url.Action("Index", "Member", new { area = "Services" }), new { pageIndex = 0, pageSize = 10 });
            return View(obj);
        }
    }
}