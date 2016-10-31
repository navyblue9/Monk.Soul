﻿using System.Linq;
using System.Web.Mvc;
using SqlSugar;
using AutoMapper;
using Monk.Utils;
using Monk.DbStore;
using Monk.Areas.Backend.ViewModels;
using Monk.Models;
using System.Collections.Generic;
using AutoMapper.Configuration;
using System;

namespace Monk.Areas.Backend.Injections
{
    public class HaviorInfoInjectionAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
            var _area = filterContext.RouteData.DataTokens["area"];
            if (_area != null && Keys.AccessVerifyAreas.Any(u => u.ToLower() == _area.ToString().ToLower()))
            {
                var _controller = filterContext.RouteData.Values["controller"].ToString();
                var _action = filterContext.RouteData.Values["action"].ToString();
                var _httpMethod = filterContext.HttpContext.Request.HttpMethod;

                var viewModel = new V_HaviorVM();
                var moduleList = HttpRuntimeCacheHelper.Get<List<V_ModuleVM>>(Keys.ModuleCacheKey);
                using (var services = new DbServices())
                {
                    services.Command((db) =>
                    {
                        var cfg = new MapperConfigurationExpression();
                        cfg.CreateMap<V_Havior, V_HaviorVM>();
                        cfg.CreateMap<V_Module, V_ModuleVM>();
                        Mapper.Initialize(cfg);
                        viewModel = Mapper.Map<V_HaviorVM>(db.Queryable<V_Havior>().SingleOrDefault(u => u.Area == _area.ToString() && u.Controller == _controller.ToLower() && u.Action == _action.ToLower() && u.HttpMethod == _httpMethod.ToUpper()));
                        if (moduleList == null)
                        {
                            moduleList = Mapper.Map<List<V_ModuleVM>>(db.Queryable<V_Module>().Where(c => true).ToList());
                            HttpRuntimeCacheHelper.Set(Keys.ModuleCacheKey, moduleList);
                        }
                    });
                }

                // 生成面包屑导航
                if (viewModel != null)
                {
                    var crumbHtml = string.Empty;
                    CreateCrumbs(moduleList, viewModel.ModuleID, ref crumbHtml);
                    viewModel.Crumbs = crumbHtml + "<label class=\"backend-crumbs-separator\">/</label>\r\n<a href=\"" + viewModel.Url + "\" title=\"" + viewModel.Name + "\">" + viewModel.Name + "</a>";
                }

                var result = filterContext.Result;
                if (result is ViewResult)
                {
                    var vresult = result as ViewResult;
                    vresult.ViewData[Keys.HaviorInfoInjectionKey] = viewModel == null ? new V_HaviorVM() : viewModel;
                    filterContext.Result = vresult;
                }
                else if (result is PartialViewResult)
                {
                    var presult = result as PartialViewResult;
                    presult.ViewData[Keys.HaviorInfoInjectionKey] = viewModel == null ? new V_HaviorVM() : viewModel;
                    filterContext.Result = presult;
                }
            }
        }

        public void CreateCrumbs(List<V_ModuleVM> list, Guid moduleId, ref string crumbHtml)
        {
            var model = list.SingleOrDefault(u => u.ModuleID == moduleId);
            if (model != null)
            {
                crumbHtml = "<label class=\"backend-crumbs-separator\">/</label>\r\n<a href=\"" + model.Url + "\" title=\"" + model.Name + "\">" + model.Name + "</a>" + crumbHtml;
                CreateCrumbs(list, model.ParentID, ref crumbHtml);
            }
        }
    }
}