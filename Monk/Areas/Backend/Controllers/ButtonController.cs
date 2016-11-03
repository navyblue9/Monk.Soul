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
    public class ButtonController : BaseController
    {
        public ButtonController(DbServices services) : base(services) { }

        [HttpGet]
        public ActionResult Select() { return View(); }

        [HttpGet]
        public JsonResult List(int? pageSize, int pageIndex = 0)
        {
            var clientResult = new JsonData<List<V_ButtonVM>>();
            var setVewModel = RouteData.DataTokens[Keys.SysSetInfoInjectionKey] as SysSetVM;
            pageSize = pageSize == null ? setVewModel.PageSize : pageSize;

            services.Command((db) =>
            {
                var query = db.Queryable<V_Button>().Where(c => true);
                var total = query.Count();
                var list = query.OrderBy(u => u.SerialNo, OrderByType.desc).ToPageList(Convert.ToInt32(pageIndex + 1), Convert.ToInt32(pageSize));

                Mapper.Initialize(c => c.CreateMap<V_Button, V_ButtonVM>());
                clientResult.SetClientData("y", "获取成功", Mapper.Map<List<V_ButtonVM>>(list), new { pageSize, pageIndex = Convert.ToInt32(pageIndex + 1), total });
            });
            return Json(clientResult, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Insert() { return View(new ButtonVM() { Enable = true, Event = "onclick" }); }

        [HttpGet]
        public JsonResult Haviors(string query)
        {
            var clientResult = new AutoCompleteResult() { query = query, suggestions = new List<Suggestion>() { } };
            if (!string.IsNullOrEmpty(query))
            {
                services.Command((db) =>
                {
                    var list = db.Queryable<Havior>().Where(u => u.Name.Contains(query)).ToList();
                    foreach (var item in list)
                    {
                        clientResult.suggestions.Add(new Suggestion()
                        {
                            value = item.Name,
                            data = item.HaviorID
                        });
                    }
                });
            }
            return Json(clientResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Insert(ButtonVM viewModel)
        {
            var clientResult = new JsonData<object>();
            var sessionModel = Session[Keys.SessionKey] as MemberSessionVM;
            viewModel.LogMemberID = sessionModel.MemberID;

            Mapper.Initialize(u => u.CreateMap<ButtonVM, Button>());
            var model = Mapper.Map<Button>(viewModel);
            model.ButtonID = Guid.NewGuid();

            services.Command((db) =>
            {
                db.Insert<Button>(model);
                clientResult.SetClientData("y", "操作成功", new { id = model.ButtonID });
            });
            return Json(clientResult);
        }

        [HttpGet]
        public ActionResult Detail(Guid? id)
        {
            if (id == null) return Content("非法参数");
            var viewModel = new V_ButtonVM();
            services.Command((db) =>
            {
                Mapper.Initialize(c => c.CreateMap<V_Button, V_ButtonVM>());
                viewModel = Mapper.Map<V_ButtonVM>(db.Queryable<V_Button>().SingleOrDefault(u => u.ButtonID == id));
            });
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Update(Guid? id)
        {
            if (id == null) return Content("非法参数");
            var viewModel = new V_ButtonVM();
            services.Command((db) =>
            {
                Mapper.Initialize(c => c.CreateMap<V_Button, V_ButtonVM>());
                viewModel = Mapper.Map<V_ButtonVM>(db.Queryable<V_Button>().SingleOrDefault(u => u.ButtonID == id));
            });
            return View(viewModel);
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Update(V_ButtonVM viewModel)
        {
            var clientResult = new JsonData<object>() { };
            if (viewModel.ButtonID == null) clientResult.SetClientData("n", "非法参数");

            services.Command((db) =>
            {
                db.Update<Button>(new
                {
                    viewModel.HaviorID,
                    viewModel.Name,
                    viewModel.Remark,
                    viewModel.Sort,
                    viewModel.Event,
                    viewModel.Invoke,
                    viewModel.Handle,
                    viewModel.TagAttr,
                    viewModel.Iconfont,
                    viewModel.Enable,
                    UpdateTime = DateTime.Now
                }, u => u.ButtonID == viewModel.ButtonID);

                clientResult.SetClientData("y", "操作成功");
            });
            return Json(clientResult);
        }
    }
}