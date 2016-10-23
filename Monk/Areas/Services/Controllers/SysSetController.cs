using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.Configuration;
using SqlSugar;
using Monk.DbStore;
using Monk.Models;
using Monk.ViewModels;
using Monk.Utils;

namespace Monk.Areas.Services.Controllers
{
    public class SysSetController : BaseController
    {
        public SysSetController(DbServices services) : base(services) { }

        [HttpGet]
        public JsonResult Detail(Guid? setID)
        {
            var clientResult = new JsonData<SysSetViewModel>() { };
            var sysSet = new SysSet();
            services.Command((db) =>
            {
                if (setID != null) sysSet = db.Queryable<SysSet>().InSingle(setID);
                else sysSet = db.Queryable<SysSet>().FirstOrDefault();
            });

            // 此地方需要重点优化，后期使用autofac统一注入
            var cfg = new MapperConfigurationExpression();
            cfg.CreateMap<SysSet, SysSetViewModel>();
            Mapper.Initialize(cfg);
            var viewModel = Mapper.Map<SysSetViewModel>(sysSet);

            clientResult.SetClientData("y", "操作成功", viewModel);
            return Json(clientResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Update(SysSetViewModel model)
        {
            var clientResult = new JsonData<object>() { };
            if (model.SetID == null) clientResult.SetClientData("n", "非法参数");
            services.Command((db) =>
            {
                db.Update<SysSet>(new
                {
                    model.Logo,
                    model.Name,
                    model.Version,
                    model.Keywords,
                    model.Description,
                    model.CopyRight,
                    model.Site,
                    model.ImageMaxSize,
                    model.VideoMaxSize,
                    model.AttachMaxSize,
                    UpdateTime = DateTime.Now
                }, u => u.SetID == model.SetID);

                clientResult.SetClientData("y", "操作成功");
            });

            return Json(clientResult);
        }
    }
}