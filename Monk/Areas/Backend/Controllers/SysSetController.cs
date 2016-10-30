using System;
using System.Linq;
using System.Web.Mvc;
using SqlSugar;
using AutoMapper;
using Monk.Models;
using Monk.Areas.Backend.ViewModels;
using Monk.DbStore;
using Monk.Utils;

namespace Monk.Areas.Backend.Controllers
{
    public class SysSetController : BaseController
    {
        public SysSetController(DbServices services) : base(services) { }

        [HttpGet]
        public ActionResult Detail()
        {
            var viewModel = new SysSetVM();
            services.Command((db) =>
            {
                Mapper.Initialize(c => c.CreateMap<SysSet, SysSetVM>());
                viewModel = Mapper.Map<SysSetVM>(db.Queryable<SysSet>().FirstOrDefault());
            });
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Update(Guid? id)
        {
            if (id == null) return Content("非法参数");
            var viewModel = new SysSetVM();
            services.Command((db) =>
            {
                Mapper.Initialize(c => c.CreateMap<SysSet, SysSetVM>());
                viewModel = Mapper.Map<SysSetVM>(db.Queryable<SysSet>().InSingle(id));
            });
            return View(viewModel);
        }

        [HttpPost]
        public JsonResult Update(SysSetVM viewModel)
        {
            var clientResult = new JsonData<object>() { };
            if (viewModel.SetID == null) clientResult.SetClientData("n", "非法参数");
            services.Command((db) =>
            {
                db.Update<SysSet>(new
                {
                    viewModel.Logo,
                    viewModel.Name,
                    viewModel.Version,
                    viewModel.Keywords,
                    viewModel.Description,
                    viewModel.Copyright,
                    viewModel.Site,
                    viewModel.ImageMaxSize,
                    viewModel.VideoMaxSize,
                    viewModel.AttachMaxSize,
                    viewModel.PageSize,
                    UpdateTime = DateTime.Now
                }, u => u.SetID == viewModel.SetID);
                HttpRuntimeCacheHelper.Remove(Keys.SysSetCacheKey);
                clientResult.SetClientData("y", "操作成功");
            });
            return Json(clientResult);
        }
    }
}