using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SyntacticSugar;
using Monk.Filters;

namespace Monk.Areas.Services.Controllers
{
    [Anonymous]
    public class CommonController : Controller
    {
        [HttpPost]
        public JsonResult UploadImage()
        {
            return Json(null);
        }
    }
}