using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Monk.Utils;

namespace Monk.Areas.Backend.Controllers
{
    public class CacheController : Controller
    {
        [HttpGet]
        public ActionResult Select() { return View(); }

        [HttpGet]
        public JsonResult RuntimeCache()
        {
            var clientResult = new JsonData<List<object>>();
            var list = new List<object>();
            var caches = HttpRuntime.Cache.GetEnumerator();
            while (caches.MoveNext())
            {
                list.Add(new
                {
                    Current = caches.Current
                });
            }
            clientResult.SetClientData("y", "获取成功", list);
            return Json(clientResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Detail(string id)
        {
            ViewBag.Key = id;
            ViewBag.Value = JsonConvert.SerializeObject(HttpRuntime.Cache.Get(id));
            return View();
        }

        [HttpPost]
        public JsonResult Delete(string ids)
        {
            var clientResult = new JsonData<List<object>>();
            string[] arr = ids.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < arr.Length; i++)
            {
                CacheManager.Remove(arr[i]);
            }
            clientResult.SetClientData("y", "操作成功");
            return Json(clientResult);
        }
    }
}