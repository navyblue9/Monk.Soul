using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Monk.Areas.Backend.Controllers
{
    public class LoginLogController : Controller
    {
        [HttpGet]
        public ActionResult Select()
        {
            return View();
        }
    }
}