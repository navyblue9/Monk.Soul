using System;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using SqlSugar;
using AutoMapper;
using AutoMapper.Configuration;
using Monk.Models;
using Monk.Areas.Backend.ViewModels;
using Monk.DbStore;
using Monk.Utils;
using Monk.Areas.Backend.App_Code;

namespace Monk.Areas.Backend.Controllers
{
    public class ModuleController : BaseController
    {
        public ModuleController(DbServices services) : base(services) { }

        [HttpGet]
        public ActionResult Select() { return View(); }

        [HttpGet]
        public JsonResult List()
        {
            var clientResult = new JsonData<List<V_ModuleVM>>();
            var cache = HttpRuntimeCacheHelper.Get<List<V_ModuleVM>>(Keys.ModuleCacheKey);
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

        [HttpGet]
        public ActionResult Insert(Guid? id)
        {
            var moduleList = new List<V_ModuleVM>();
            var cache = HttpRuntimeCacheHelper.Get<List<V_ModuleVM>>(Keys.ModuleCacheKey);
            if (cache == null)
            {
                services.Command((db) =>
                {
                    Mapper.Initialize(u => u.CreateMap<V_Module, V_ModuleVM>());
                    moduleList = Mapper.Map<List<V_ModuleVM>>(db.Queryable<V_Module>().Where(c => true).ToList());
                    HttpRuntimeCacheHelper.Set(Keys.ModuleCacheKey, moduleList);
                });
            }
            else moduleList = cache;

            ViewData["ModuleList"] = Common.ModuleDropDownList(moduleList, id);
            return View(new ModuleVM() { Enable = true, Iconfont = "icon-backend-file", Sort = 0 });
        }

        [HttpPost]
        public JsonResult Insert(ModuleVM viewModel)
        {
            var clientResult = new JsonData<object>();
            var sessionModel = Session[Keys.SessionKey] as MemberSessionVM;
            viewModel.LogMemberID = sessionModel.MemberID;
            viewModel.Remark = string.IsNullOrEmpty(viewModel.Remark) ? viewModel.Name : viewModel.Remark;
            viewModel.Iconfont = string.IsNullOrEmpty(viewModel.Iconfont) ? "icon-backend-file" : viewModel.Iconfont;

            Mapper.Initialize(u => u.CreateMap<ModuleVM, Module>());
            var model = Mapper.Map<Module>(viewModel);
            model.ModuleID = Guid.NewGuid();

            services.Command((db) =>
            {
                db.Insert<Module>(model);
                HttpRuntimeCacheHelper.Remove(Keys.ModuleCacheKey);
                clientResult.SetClientData("y", "操作成功", new { id = model.ModuleID });
            });
            return Json(clientResult);
        }

        [HttpGet]
        public ActionResult Detail(Guid? id)
        {
            if (id == null) return Content("非法参数");
            var viewModel = new V_ModuleVM();
            services.Command((db) =>
            {
                Mapper.Initialize(c => c.CreateMap<V_Module, V_ModuleVM>());
                viewModel = Mapper.Map<V_ModuleVM>(db.Queryable<V_Module>().SingleOrDefault(u => u.ModuleID == id));
            });
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Update(Guid? id)
        {
            if (id == null) return Content("非法参数");
            var viewModel = new ModuleVM();
            var moduleList = new List<V_ModuleVM>();
            var cache = HttpRuntimeCacheHelper.Get<List<V_ModuleVM>>(Keys.ModuleCacheKey);
            if (cache != null) moduleList = cache;
            services.Command((db) =>
            {
                var cfg = new MapperConfigurationExpression();
                cfg.CreateMap<Module, ModuleVM>();
                cfg.CreateMap<V_Module, V_ModuleVM>();
                Mapper.Initialize(cfg);

                viewModel = Mapper.Map<ModuleVM>(db.Queryable<Module>().InSingle(id));
                if (cache == null)
                {
                    moduleList = Mapper.Map<List<V_ModuleVM>>(db.Queryable<V_Module>().Where(c => true).ToList());
                    HttpRuntimeCacheHelper.Set(Keys.ModuleCacheKey, moduleList);
                }
            });
            ViewData["ModuleList"] = Common.ModuleDropDownList(moduleList, viewModel.ParentID);
            return View(viewModel);
        }

        [HttpPost]
        public JsonResult Update(ModuleVM viewModel)
        {
            var clientResult = new JsonData<object>() { };
            if (viewModel.ModuleID == null) clientResult.SetClientData("n", "非法参数");
            viewModel.Remark = string.IsNullOrEmpty(viewModel.Remark) ? viewModel.Name : viewModel.Remark;
            viewModel.Iconfont = string.IsNullOrEmpty(viewModel.Iconfont) ? "icon-backend-file" : viewModel.Iconfont;

            if (viewModel.ModuleID == viewModel.ParentID) clientResult.SetClientData("n", "上级栏目不能是本身栏目");
            else
            {
                services.Command((db) =>
                {
                    db.Update<Module>(new
                    {
                        viewModel.Enable,
                        viewModel.Iconfont,
                        viewModel.Name,
                        viewModel.ParentID,
                        viewModel.Remark,
                        viewModel.Sort,
                        viewModel.TagAttr,
                        UpdateTime = DateTime.Now
                    }, u => u.ModuleID == viewModel.ModuleID);
                    HttpRuntimeCacheHelper.Remove(Keys.ModuleCacheKey);
                    clientResult.SetClientData("y", "操作成功");
                });
            }
            return Json(clientResult);
        }

        [HttpPost]
        public JsonResult Delete(List<Guid> ids)
        {
            var clientResult = new JsonData<object>() { };
            if (ids.Contains(Guid.Parse("11111111-1111-1111-1111-111111111111"))) clientResult.SetClientData("n", "操作失败，根站点栏目属于顶级栏目，禁止删除");
            else
            {
                services.Command((db) =>
                {
                    db.BeginTran();
                    try
                    {
                        var filterList = new List<Guid>();
                        var deletes = db.Queryable<Module>().Where(u => ids.Contains(u.ModuleID)).ToList();
                        deletes.ForEach(u =>
                        {
                            if (u.Default == false) filterList.Add(u.ModuleID);
                        });

                        db.FalseDelete<Module>("Del", u => filterList.Contains(u.ModuleID));
                        db.CommitTran();
                        HttpRuntimeCacheHelper.Remove(Keys.ModuleCacheKey);
                        if (ids.Count() == filterList.Count()) clientResult.SetClientData("y", "操作成功");
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
            }
            return Json(clientResult);
        }
    }
}