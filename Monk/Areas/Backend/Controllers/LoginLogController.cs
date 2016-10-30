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
    public class LoginLogController : BaseController
    {
        public LoginLogController(DbServices services) : base(services) { }

        [HttpGet]
        public ActionResult Select() { return View(); }

        [HttpGet]
        public JsonResult List(int? pageSize, int? pageIndex = 0, string account = "", string sucessed = null)
        {
            var clientResult = new JsonData<List<LoginLogVM>>();
            var whereStr = "Account like @account and Sucessed like @sucessed";
            var setVewModel = RouteData.DataTokens[Keys.SysSetInfoInjectionKey] as SysSetVM;
            pageSize = pageSize == null ? setVewModel.PageSize : pageSize;

            services.Command((db) =>
            {
                var query = db.Queryable<LoginLog>().Where(c => true).Where(whereStr, new { account = "%" + account + "%", sucessed = "%" + sucessed + "%" });
                var total = query.Count();
                var list = query.OrderBy(u => u.InTime, OrderByType.desc).ToPageList(Convert.ToInt32(pageIndex + 1), Convert.ToInt32(pageSize));

                Mapper.Initialize(c => c.CreateMap<LoginLog, LoginLogVM>());
                clientResult.SetClientData("y", "获取成功", Mapper.Map<List<LoginLogVM>>(list), new { pageSize, pageIndex = Convert.ToInt32(pageIndex + 1), total });
            });
            return Json(clientResult, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Detail(Guid id)
        {
            if (id == null) return Content("非法参数");
            var viewModel = new LoginLogVM();
            services.Command((db) =>
            {
                Mapper.Initialize(c => c.CreateMap<LoginLog, LoginLogVM>());
                viewModel = Mapper.Map<LoginLogVM>(db.Queryable<LoginLog>().InSingle(id));
            });
            return View(viewModel);
        }

        [HttpPost]
        public JsonResult Delete(List<Guid> ids)
        {
            var clientResult = new JsonData<List<LoginLogVM>>();
            services.Command((db) =>
            {
                db.BeginTran();
                try
                {
                    db.FalseDelete<LoginLog>("Del", u => ids.Contains(u.LogID));
                    db.CommitTran();
                    clientResult.SetClientData("y", "操作成功");
                }
                catch (Exception ex)
                {
                    db.RollbackTran();
                    clientResult.SetClientData("n", "操作失败", null, new
                    {
                        ex.Message,
                        ex.Source
                    });
                }
            });
            return Json(clientResult);
        }
    }
}