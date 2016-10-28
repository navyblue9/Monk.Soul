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
    public class HaviorController : BaseController
    {
        public HaviorController(DbServices services) : base(services) { }

        [HttpGet]
        public JsonResult Select(int? pageSize, int? pageIndex = 0)
        {
            var clientResult = new JsonData<List<V_HaviorVM>>() { };

            var setVewModel = RouteData.DataTokens[Keys.SysSetInfoInjectionKey] as SysSetVM;
            pageSize = pageSize == null ? setVewModel.PageSize : pageSize;
            services.Command((db) =>
            {
                var query = db.Queryable<V_Havior>().Where(c => true);
                var total = query.Count();
                var list = query.OrderBy(u => u.SerialNo, OrderByType.desc).ToPageList(Convert.ToInt32(pageIndex + 1), Convert.ToInt32(pageSize));

                // 此地方需要重点优化，后期使用autofac统一注入
                Mapper.Initialize(c => c.CreateMap<V_Havior, V_HaviorVM>());

                clientResult.SetClientData("y", "获取成功", Mapper.Map<List<V_HaviorVM>>(list), new
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