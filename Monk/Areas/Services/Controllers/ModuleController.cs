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
                    HttpRuntimeCacheHelper.Set(Keys.ModuleCacheKey, list);
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
                HttpRuntimeCacheHelper.Remove(Keys.ModuleCacheKey);
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

            if (model.ModuleID == model.ParentID)
            {
                clientResult.SetClientData("n", "上级栏目不能是本身栏目");
                return Json(clientResult);
            }

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

                HttpRuntimeCacheHelper.Remove(Keys.ModuleCacheKey);
                clientResult.SetClientData("y", "操作成功");
            });

            return Json(clientResult);
        }

        [HttpPost]
        public JsonResult Delete(string ids)
        {
            var clientResult = new JsonData<object>() { };
            var list = ids.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(u => Guid.Parse(u));
            if (list.Contains(Guid.Parse("11111111-1111-1111-1111-111111111111")))
            {
                clientResult.SetClientData("n", "操作失败，根站点栏目属于顶级栏目，禁止删除");
                return Json(clientResult);
            }
            services.Command((db) =>
            {
                db.BeginTran();
                try
                {
                    // 默认数据判断，默认数据禁止删除
                    var allowList = new List<Guid>();
                    var deletes = db.Queryable<Module>().Where(u => list.Contains(u.ModuleID)).ToList();
                    deletes.ForEach(u =>
                    {
                        if (u.Default == false)
                        {
                            allowList.Add(u.ModuleID);
                        }
                    });

                    db.FalseDelete<Module>("Del", u => allowList.Contains(u.ModuleID));
                    db.CommitTran();
                    HttpRuntimeCacheHelper.Remove(Keys.ModuleCacheKey);
                    if (list.Count() == allowList.Count()) clientResult.SetClientData("y", "操作成功");
                    else clientResult.SetClientData("y", "操作成功，但不包括默认数据");
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