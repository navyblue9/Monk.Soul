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
using Monk.Injections;

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

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Insert(HaviorVM viewModel)
        {
            var clientResult = new JsonData<object>();
            Mapper.Initialize(u => u.CreateMap<HaviorVM, Havior>());
            var model = Mapper.Map<Havior>(viewModel);
            model.HaviorID = Guid.NewGuid();
            model.Area = string.IsNullOrEmpty(model.Area) ? model.Area : model.Area.ToLower();
            model.Action = string.IsNullOrEmpty(model.Action) ? model.Area : model.Action.ToLower();
            model.Controller = string.IsNullOrEmpty(model.Controller) ? model.Area : model.Controller.ToLower();

            services.Command((db) =>
            {
                if (model.Index == true)
                {
                    db.Update<Havior>(new { Index = false }, u => u.ModuleID == model.ModuleID);
                }
                db.Insert<Havior>(model);

                HttpRuntimeCacheHelper.Remove(Keys.ModuleCacheKey);
                clientResult.SetClientData("y", "操作成功", new { id = model.HaviorID });
            });
            return Json(clientResult);
        }

        [HttpGet]
        public JsonResult Detail(Guid? haviorId)
        {
            var clientResult = new JsonData<V_HaviorVM>() { };
            var model = new V_Havior();
            services.Command((db) =>
            {
                model = db.Queryable<V_Havior>().SingleOrDefault(u => u.HaviorID == haviorId);
            });

            // 此地方需要重点优化，后期使用autofac统一注入
            Mapper.Initialize(c => c.CreateMap<V_Havior, V_HaviorVM>());

            clientResult.SetClientData("y", "操作成功", Mapper.Map<V_HaviorVM>(model));
            return Json(clientResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Update(HaviorVM model)
        {
            var clientResult = new JsonData<object>() { };
            if (model.HaviorID == null) clientResult.SetClientData("n", "非法参数");
            model.Area = string.IsNullOrEmpty(model.Area) ? model.Area : model.Area.ToLower();
            model.Action = string.IsNullOrEmpty(model.Action) ? model.Area : model.Action.ToLower();
            model.Controller = string.IsNullOrEmpty(model.Controller) ? model.Area : model.Controller.ToLower();

            services.Command((db) =>
            {
                if (model.Index == true)
                {
                    db.Update<Havior>(new { Index = false }, u => u.ModuleID == model.ModuleID);
                }

                db.Update<Havior>(new
                {
                    model.Action,
                    model.Area,
                    model.Controller,
                    model.FootCode,
                    model.HeadCode,
                    model.HttpMethod,
                    model.Index,
                    model.Layout,
                    model.ModuleID,
                    model.Name,
                    model.Parameter,
                    model.Remark,
                    model.Route,
                    model.Url,
                    model.Enable,
                    UpdateTime = DateTime.Now
                }, u => u.HaviorID == model.HaviorID);

                HttpRuntimeCacheHelper.Remove(Keys.ModuleCacheKey);
                clientResult.SetClientData("y", "操作成功");
            });

            return Json(clientResult);
        }

        [HttpGet]
        public JsonResult HaviorInfo(string _area, string _controller, string _action, string _httpMethod)
        {
            var clientResult = new JsonData<V_HaviorVM>() { };
            var model = new V_Havior();
            services.Command((db) =>
            {
                model = db.Queryable<V_Havior>().SingleOrDefault(u => u.Area == _area.ToLower() && u.Controller == _controller.ToLower() && u.Action == _action.ToLower() && u.HttpMethod == _httpMethod.ToUpper());
            });

            // 此地方需要重点优化，后期使用autofac统一注入
            Mapper.Initialize(c => c.CreateMap<V_Havior, V_HaviorVM>());

            clientResult.SetClientData("y", "操作成功", Mapper.Map<V_HaviorVM>(model));
            return Json(clientResult, JsonRequestBehavior.AllowGet);
        }
    }
}