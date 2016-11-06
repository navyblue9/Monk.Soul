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
        public ActionResult Insert() { return View(); }
    }
}