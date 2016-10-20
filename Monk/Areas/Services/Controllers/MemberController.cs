using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Monk.DbStore;

namespace Monk.Areas.Services.Controllers
{
    public class MemberController : BaseController
    {
        public MemberController(DbServices services) : base(services) { }

        [HttpPost]
        public JsonResult Index(int pageIndex, int pageSize)
        {
            return Json(new { success = "ok", pageIndex = pageIndex, pageSize = pageSize });
        }
    }
}