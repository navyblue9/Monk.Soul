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
            var clientResult = new JsonData<List<ModuleVM>>();
            return Json(clientResult, JsonRequestBehavior.AllowGet);
        }
    }
}