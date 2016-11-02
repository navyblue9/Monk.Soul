using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Linq;
using Monk.Utils;
using Monk.Areas.Backend.ViewModels;

namespace Monk.Areas.Backend.Controllers
{
    public class CacheController : Controller
    {
        [HttpGet]
        public ActionResult Select() { return View(); }

        [HttpGet]
        public JsonResult List(int? pageSize, int pageIndex = 0)
        {
            var clientResult = new JsonData<List<CacheVM>>();
            var setVewModel = RouteData.DataTokens[Keys.SysSetInfoInjectionKey] as SysSetVM;
            pageSize = pageSize == null ? setVewModel.PageSize : pageSize;

            var list = new List<CacheVM>();
            var caches = HttpRuntime.Cache.GetEnumerator();
            while (caches.MoveNext())
            {
                list.Add(new CacheVM()
                {
                    Key = caches.Key.ToString()
                });
            }
            clientResult.SetClientData("y", "获取成功", list.OrderBy(u => u.Key).Skip(((pageIndex + 1) - 1) * Convert.ToInt32(pageSize)).Take(Convert.ToInt32(pageSize)).ToList(), new { pageSize, pageIndex = Convert.ToInt32(pageIndex + 1), total = list.Count() });
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