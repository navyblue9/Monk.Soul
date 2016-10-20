using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using RestSharp;
using SyntacticSugar;
using Monk.Models;

namespace Monk.Areas.Backend.Controllers
{
    public class AuthorizeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}