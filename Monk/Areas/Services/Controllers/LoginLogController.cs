using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.Configuration;
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
        public JsonResult Select(int? pageSize, int? pageIndex = 0, string whereString = "", Dictionary<string, object> whereObj = null)
        {
            var clientResult = new JsonData<List<LoginLogViewModel>>() { };
            var setVewModel = RouteData.DataTokens[Keys.SysSetInfoInjectionKey] as SysSetViewModel;
            pageSize = pageSize == null ? setVewModel.PageSize : pageSize;
            services.Command((db) =>
            {
                var query = db.Queryable<LoginLog>().Where(c => true);
                if (!string.IsNullOrEmpty(whereString) && whereObj != null)
                {
                    query = query.Where(whereString, whereString);
                }
                var total = query.Count();
                var list = query.OrderBy(u => u.InTime, OrderByType.desc).ToPageList(Convert.ToInt32(pageIndex + 1), Convert.ToInt32(pageSize));

                // 此地方需要重点优化，后期使用autofac统一注入
                var cfg = new MapperConfigurationExpression();
                cfg.CreateMap<LoginLog, LoginLogViewModel>();
                Mapper.Initialize(cfg);

                var viewModels = Mapper.Map<List<LoginLogViewModel>>(list);
                clientResult.SetClientData("y", "获取成功", viewModels, new
                {
                    pageSize,
                    pageIndex = Convert.ToInt32(pageIndex + 1),
                    total
                });
            });
            return Json(clientResult, JsonRequestBehavior.AllowGet);
        }
    }
}