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
            var clientResult = new JsonData<SysSet>() { };
            services.Command((db) =>
            {
                if (setID != null) clientResult.SetClientData("y", "操作成功", db.Queryable<SysSet>().InSingle(setID));
                else clientResult.SetClientData("y", "操作成功", db.Queryable<SysSet>().FirstOrDefault());
            });

            return Json(clientResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Update(SysSet model)
        {
            var clientResult = new JsonData<object>() { };
            if (model.SetID == null) clientResult.SetClientData("n", "非法参数");
            services.Command((db) =>
            {
                db.Update<SysSet>(new
                {
                    model.Logo,
                    model.Name,
                    model.Version,
                    model.Keywords,
                    model.Description,
                    model.CopyRight,
                    model.Site,
                    model.ImageMaxSize,
                    model.VideoMaxSize,
                    model.AttachMaxSize,
                    UpdateTime = DateTime.Now
                }, u => u.SetID == model.SetID);

                clientResult.SetClientData("y", "操作成功");
            });

            return Json(clientResult);
        }
    }
}