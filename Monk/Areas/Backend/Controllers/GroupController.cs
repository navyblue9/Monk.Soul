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
    public class GroupController : BaseController
    {
        public GroupController(DbServices services) : base(services) { }

        [HttpGet]
        public ActionResult Select() { return View(); }

        [HttpGet]
        public JsonResult List()
        {
            var clientResult = new JsonData<List<V_GroupVM>>();
            services.Command((db) =>
            {
                Mapper.Initialize(u => u.CreateMap<V_Group, V_GroupVM>());
                var list = Mapper.Map<List<V_GroupVM>>(db.Queryable<V_Group>().Where(c => true).ToList());
                clientResult.SetClientData("y", "获取成功", list);
            });
            return Json(clientResult, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Insert(Guid? id)
        {
            services.Command((db) =>
            {
                Mapper.Initialize(u => u.CreateMap<V_Group, V_GroupVM>());
                ViewData["GroupList"] = Common.GroupDropDownList(Mapper.Map<List<V_GroupVM>>(db.Queryable<V_Group>().Where(c => true).ToList()), id);
            });
            return View(new GroupVM() { Enable = true });
        }

        [HttpPost]
        public JsonResult Insert(GroupVM viewModel)
        {
            var clientResult = new JsonData<object>();
            var sessionModel = Session[Keys.SessionKey] as MemberSessionVM;
            viewModel.LogMemberID = sessionModel.MemberID;
            viewModel.Remark = string.IsNullOrEmpty(viewModel.Remark) ? viewModel.Name : viewModel.Remark;

            Mapper.Initialize(u => u.CreateMap<GroupVM, Group>());
            var model = Mapper.Map<Group>(viewModel);
            model.GroupID = Guid.NewGuid();

            services.Command((db) =>
            {
                db.Insert<Group>(model);
                clientResult.SetClientData("y", "操作成功", new { id = model.GroupID });
            });
            return Json(clientResult);
        }

        [HttpGet]
        public ActionResult Detail(Guid? id)
        {
            if (id == null) return Content("非法参数");
            var viewModel = new V_GroupVM();
            services.Command((db) =>
            {
                Mapper.Initialize(c => c.CreateMap<V_Group, V_GroupVM>());
                viewModel = Mapper.Map<V_GroupVM>(db.Queryable<V_Group>().SingleOrDefault(u => u.GroupID == id));
            });
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Update(Guid? id)
        {
            if (id == null) return Content("非法参数");
            var viewModel = new GroupVM();
            services.Command((db) =>
            {
                var cfg = new MapperConfigurationExpression();
                cfg.CreateMap<Group, GroupVM>();
                cfg.CreateMap<V_Group, V_GroupVM>();
                Mapper.Initialize(cfg);

                viewModel = Mapper.Map<GroupVM>(db.Queryable<Group>().InSingle(id));
                ViewData["GroupList"] = Common.GroupDropDownList(Mapper.Map<List<V_GroupVM>>(db.Queryable<V_Group>().Where(c => true).ToList()), viewModel.ParentID);
            });
            return View(viewModel);
        }

        [HttpPost]
        public JsonResult Update(GroupVM viewModel)
        {
            var clientResult = new JsonData<object>() { };
            if (viewModel.GroupID == null) clientResult.SetClientData("n", "非法参数");
            viewModel.Remark = string.IsNullOrEmpty(viewModel.Remark) ? viewModel.Name : viewModel.Remark;

            if (viewModel.GroupID == viewModel.ParentID) clientResult.SetClientData("n", "上级会员组不能是本身会员组");
            else
            {
                services.Command((db) =>
                {
                    db.Update<Group>(new
                    {
                        viewModel.Enable,
                        viewModel.Name,
                        viewModel.ParentID,
                        viewModel.Remark,
                        UpdateTime = DateTime.Now
                    }, u => u.GroupID == viewModel.GroupID);
                    clientResult.SetClientData("y", "操作成功");
                });
            }
            return Json(clientResult);
        }
    }
}