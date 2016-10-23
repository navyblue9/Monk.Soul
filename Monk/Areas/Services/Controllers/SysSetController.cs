using System;
using System.Linq.Expressions;
using System.Linq;
using System.Web.Mvc;
using SqlSugar;
using SyntacticSugar;
using Monk.DbStore;
using Monk.Models;
using Monk.Utils;
using Monk.Filters;

namespace Monk.Areas.Services.Controllers
{
    public class SysSetController : BaseController
    {
        public SysSetController(DbServices services) : base(services) { }

        [HttpGet]
        public JsonResult Detail(Guid? setID)
        {
            JsonData<SysSet> clientResult = new JsonData<SysSet>() { };
            services.Command((db) =>
            {
                if (setID != null) clientResult.SetClientData("y", "操作成功", db.Queryable<SysSet>().InSingle(setID));
                else clientResult.SetClientData("y", "操作成功", db.Queryable<SysSet>().FirstOrDefault());
            });

            return Json(clientResult, JsonRequestBehavior.AllowGet);
        }
    }
}