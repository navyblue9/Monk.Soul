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
    public class ModuleController : BaseController
    {
        public ModuleController(DbServices services) : base(services) { }

        [HttpGet]
        public JsonResult Modules()
        {
            var clientResult = new JsonData<List<V_ModuleVM>>();
            var cache = HttpRuntimeCacheHelper.Get<List<V_ModuleVM>>("Module_CacheKey");
            if (cache == null)
            {
                services.Command((db) =>
                {
                    Mapper.Initialize(u => u.CreateMap<V_Module, V_ModuleVM>());
                    var list = Mapper.Map<List<V_ModuleVM>>(db.Queryable<V_Module>().Where(c => true).ToList());
                    HttpRuntimeCacheHelper.Set("Module_CacheKey", list);
                    clientResult.SetClientData("y", "获取成功", list);
                });
            }
            else clientResult.SetClientData("y", "获取成功", cache);
            return Json(clientResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Insert(ModuleVM viewModel)
        {
            var clientResult = new JsonData<object>();
            Mapper.Initialize(u => u.CreateMap<ModuleVM, Module>());
            var model = Mapper.Map<Module>(viewModel);
            model.ModuleID = Guid.NewGuid();
            model.LogMemberID = model.LogMemberID == null ? default(Guid) : model.LogMemberID;
            model.Remark = string.IsNullOrEmpty(model.Remark) ? model.Name : model.Remark;
            model.Iconfont = string.IsNullOrEmpty(model.Iconfont) ? "icon-backend-file" : model.Iconfont;

            services.Command((db) =>
            {
                db.Insert<Module>(model);
                HttpRuntimeCacheHelper.Remove("Module_CacheKey");
                clientResult.SetClientData("y", "操作成功", new { id = model.ModuleID });
            });
            return Json(clientResult);
        }

        [HttpGet]
        public JsonResult Detail(Guid? moduleId)
        {
            var clientResult = new JsonData<V_ModuleVM>() { };
            var model = new V_Module();
            services.Command((db) =>
            {
                model = db.Queryable<V_Module>().SingleOrDefault(u => u.ModuleID == moduleId);
            });

            // 此地方需要重点优化，后期使用autofac统一注入
            Mapper.Initialize(c => c.CreateMap<V_Module, V_ModuleVM>());

            clientResult.SetClientData("y", "操作成功", Mapper.Map<V_ModuleVM>(model));
            return Json(clientResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Update(ModuleVM model)
        {
            var clientResult = new JsonData<object>() { };
            if (model.ModuleID == null) clientResult.SetClientData("n", "非法参数");
            model.Remark = string.IsNullOrEmpty(model.Remark) ? model.Name : model.Remark;
            model.Iconfont = string.IsNullOrEmpty(model.Iconfont) ? "icon-backend-file" : model.Iconfont;
            services.Command((db) =>
            {
                db.Update<Module>(new
                {
                    model.Enable,
                    model.Iconfont,
                    model.Name,
                    model.ParentID,
                    model.Remark,
                    model.Sort,
                    model.TagAttr,
                    UpdateTime = DateTime.Now
                }, u => u.ModuleID == model.ModuleID);

                HttpRuntimeCacheHelper.Remove("Module_CacheKey");
                clientResult.SetClientData("y", "操作成功");
            });

            return Json(clientResult);
        }
    }
}