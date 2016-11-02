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
        public ActionResult Insert() { return View(new ButtonVM() { Enable = true }); }

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
    }
}