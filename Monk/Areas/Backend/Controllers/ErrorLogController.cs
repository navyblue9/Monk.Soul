using System;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using SqlSugar;
using AutoMapper;
using Monk.Models;
using Monk.Areas.Backend.ViewModels;
using Monk.DbStore;
using Monk.Utils;

namespace Monk.Areas.Backend.Controllers
{
    public class ErrorLogController : BaseController
    {
        public ErrorLogController(DbServices services) : base(services) { }

        [HttpGet]
        public ActionResult Select() { return View(); }

        [HttpGet]
        public JsonResult List(int? pageSize, int? pageIndex = 0, string account = "")
        {
            var clientResult = new JsonData<List<ErrorLogVM>>();
            var setVewModel = RouteData.DataTokens[Keys.SysSetInfoInjectionKey] as SysSetVM;
            pageSize = pageSize == null ? setVewModel.PageSize : pageSize;

            services.Command((db) =>
            {
                var query = db.Queryable<ErrorLog>().Where(c => true);
                var total = query.Count();
                var list = query.OrderBy(u => u.LogTime, OrderByType.desc).ToPageList(Convert.ToInt32(pageIndex + 1), Convert.ToInt32(pageSize));

                Mapper.Initialize(c => c.CreateMap<ErrorLog, ErrorLogVM>());
                clientResult.SetClientData("y", "获取成功", Mapper.Map<List<ErrorLogVM>>(list), new { pageSize, pageIndex = Convert.ToInt32(pageIndex + 1), total });
            });
            return Json(clientResult, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Detail(Guid id)
        {
            if (id == null) return Content("非法参数");
            var viewModel = new ErrorLogVM();
            services.Command((db) =>
            {
                db.Update<ErrorLog>(new { View = true }, u => u.LogID == id);
                Mapper.Initialize(c => c.CreateMap<ErrorLog, ErrorLogVM>());
                viewModel = Mapper.Map<ErrorLogVM>(db.Queryable<ErrorLog>().InSingle(id));
            });
            return View(viewModel);
        }
    }
}