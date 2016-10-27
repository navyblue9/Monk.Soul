using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using SqlSugar;
using Monk.DbStore;
using Monk.Models;
using Monk.ViewModels;
using Monk.Utils;
using System.Collections.Generic;

namespace Monk.Areas.Services.Controllers
{
    public class LoginLogController : BaseController
    {
        public LoginLogController(DbServices services) : base(services) { }

        [HttpGet]
        public JsonResult Select(int? pageSize, int? pageIndex = 0, string account = "", string sucessed = null)
        {
            var clientResult = new JsonData<List<LoginLogViewModel>>() { };
            var whereStr = "Account like @account and Sucessed like @sucessed";

            var setVewModel = RouteData.DataTokens[Keys.SysSetInfoInjectionKey] as SysSetViewModel;
            pageSize = pageSize == null ? setVewModel.PageSize : pageSize;
            services.Command((db) =>
            {
                var query = db.Queryable<LoginLog>().Where(c => true).Where(whereStr, new { account = "%" + account + "%", sucessed = "%" + sucessed + "%" });
                var total = query.Count();
                var list = query.OrderBy(u => u.InTime, OrderByType.desc).ToPageList(Convert.ToInt32(pageIndex + 1), Convert.ToInt32(pageSize));

                // 此地方需要重点优化，后期使用autofac统一注入
                Mapper.Initialize(c => c.CreateMap<LoginLog, LoginLogViewModel>());

                clientResult.SetClientData("y", "获取成功", Mapper.Map<List<LoginLogViewModel>>(list), new
                {
                    pageSize,
                    pageIndex = Convert.ToInt32(pageIndex + 1),
                    total
                });
            });
            return Json(clientResult, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Detail(Guid? logId)
        {
            var clientResult = new JsonData<LoginLogViewModel>() { };
            var model = new LoginLog();
            services.Command((db) =>
            {
                model = db.Queryable<LoginLog>().InSingle(logId);
            });

            // 此地方需要重点优化，后期使用autofac统一注入
            Mapper.Initialize(c => c.CreateMap<LoginLog, LoginLogViewModel>());

            clientResult.SetClientData("y", "操作成功", Mapper.Map<LoginLogViewModel>(model));
            return Json(clientResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(string ids)
        {
            var clientResult = new JsonData<object>() { };
            var list = ids.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(u => Guid.Parse(u));
            services.Command((db) =>
                {
                    db.BeginTran();
                    try
                    {
                        db.FalseDelete<LoginLog>("Del", u => list.Contains(u.LogID));
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