using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Monk.Models;
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
    }
}