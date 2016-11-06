using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using SqlSugar;
using AutoMapper;
using Monk.Models;
using Monk.DbStore;
using Monk.Utils;
using Monk.Filters;
using Monk.Areas.Backend.ViewModels;

namespace Monk.Areas.Backend.Controllers
{
    public class PermissionController : BaseController
    {
        public PermissionController(DbServices services) : base(services) { }

        [HttpGet]
        public ActionResult Group()
        {
            return View();
        }
    }
}