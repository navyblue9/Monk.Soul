using System.Linq;
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
            if (filterContext.Result is ViewResult || filterContext.Result is PartialViewResult)
            {
                var _area = filterContext.RouteData.DataTokens["area"];
                if (filterContext.Result is ViewResult || filterContext.Result is PartialViewResult)
                {
                    if (_area != null && Keys.AccessVerifyAreas.Any(u => u.ToLower() == _area.ToString().ToLower()))
                    {
                        var _controller = filterContext.RouteData.Values["controller"].ToString();
                        var _action = filterContext.RouteData.Values["action"].ToString();
                        var _httpMethod = filterContext.HttpContext.Request.HttpMethod;
                        var key = (_area.ToString() + "_" + _controller + "_" + _action + "_" + _httpMethod).ToLower();

                        var viewModel = new V_HaviorVM();
                        var buttonlist = new List<V_ButtonVM>();
                        var moduleList = new List<V_ModuleVM>();
                        if (!CacheManager.Contains(key))
                        {
                            var cfg = new MapperConfigurationExpression();
                            cfg.CreateMap<V_Havior, V_HaviorVM>();
                            cfg.CreateMap<V_Module, V_ModuleVM>();
                            cfg.CreateMap<V_Button, V_ButtonVM>();
                            Mapper.Initialize(cfg);
                            using (var services = new DbServices())
                            {
                                services.Command((db) =>
                                {
                                    viewModel = Mapper.Map<V_HaviorVM>(db.Queryable<V_Havior>().SingleOrDefault(u => u.Area == _area.ToString() && u.Controller == _controller.ToLower() && u.Action == _action.ToLower() && u.HttpMethod == _httpMethod.ToUpper()));
                                    if (!CacheManager.Contains(Keys.ModuleCacheKey))
                                    {
                                        CacheManager.Set(Keys.ModuleCacheKey, Mapper.Map<List<V_ModuleVM>>(db.Queryable<V_Module>().Where(c => true).ToList()));
                                    }

                                    buttonlist = Mapper.Map<List<V_ButtonVM>>(db.Queryable<V_Button>().Where(b => b.HaviorID == viewModel.HaviorID && b.Enable == true).OrderBy(u => u.Sort).OrderBy(u => u.ButtonID).ToList());
                                });
                            }
                            moduleList = CacheManager.Get<List<V_ModuleVM>>(Keys.ModuleCacheKey);

                            if (viewModel != null)
                            {
                                // 生成面包屑导航
                                var crumbHtml = string.Empty;
                                CreateCrumbs(moduleList, viewModel.ModuleID, ref crumbHtml);
                                viewModel.Crumbs = crumbHtml + "<label class=\"backend-crumbs-separator\">/</label>\r\n<a href=\"" + viewModel.Url + "\" title=\"" + viewModel.Name + "\">" + viewModel.Name + "</a>";
                                // 生成列表按钮
                                viewModel.SelectButtons = CreateSelectButtons(buttonlist);
                                // 生成表单按钮
                                viewModel.FormButtons = CreateFormButtons(buttonlist);

                                CacheManager.Set(key, viewModel);
                            }
                        }
                        else viewModel = CacheManager.Get<V_HaviorVM>(key);

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

        public string CreateSelectButtons(List<V_ButtonVM> list)
        {
            var scriptHtml = "\r\n<script type=\"text/javascript\">\r\n";
            var buttonHtml = "";
            foreach (var item in list)
            {
                scriptHtml += item.Handle + "\r\n";
                buttonHtml += "<span class=\"list-btn\" " + item.Event + "=\"" + item.Invoke + "\" " + item.TagAttr + " ><i class=\"monk-iconfont " + item.Iconfont + "\"></i><label>" + item.Name + "</label></span>\r\n";
            }
            scriptHtml += "\r\n</script>\r\n";

            return scriptHtml + buttonHtml;
        }

        public string CreateFormButtons(List<V_ButtonVM> list)
        {
            var scriptHtml = "\r\n<script type=\"text/javascript\">\r\n";
            var buttonHtml = "";
            foreach (var item in list)
            {
                scriptHtml += item.Handle + "\r\n";
                buttonHtml += "<input " + item.Event + "=\"" + item.Invoke + "\" " + item.TagAttr + " value=\"" + item.Name + "\">\r\n";
            }
            scriptHtml += "\r\n</script>\r\n";

            return scriptHtml + buttonHtml;
        }
    }
}