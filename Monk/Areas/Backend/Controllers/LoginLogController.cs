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
using System.Collections.Generic;
using Monk.Areas.Backend.ViewModels;

namespace Monk.Areas.Backend.Controllers
{
    public class LoginLogController : Controller
    {
        [HttpGet]
        public ActionResult Select()
        {
            return View();
        }
    }
}