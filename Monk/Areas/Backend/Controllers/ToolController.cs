using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Monk.Areas.Backend.Controllers
{
    public class ToolController : Controller
    {
        public ActionResult GUID()
        {
            ViewBag.GUID = Guid.NewGuid();
            return View();
        }
    }
}