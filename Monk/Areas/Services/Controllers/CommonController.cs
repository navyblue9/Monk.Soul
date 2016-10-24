using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SyntacticSugar;
using Monk.Filters;
using Monk.Utils;
using Monk.ViewModels;

namespace Monk.Areas.Services.Controllers
{
    [Anonymous]
    public class CommonController : Controller
    {
        [HttpPost]
        public JsonResult UploadImage()
        {
            var clientResult = new JsonData<object>() { };
            // 获取路由系统消息
            var setVewModel = RouteData.DataTokens["SysSetInfo"] as SysSetViewModel;
            if (setVewModel == null) clientResult.SetClientData("n", "非法上传");
            else
            {
                var maxSize = setVewModel.ImageMaxSize;
                var upload = new UploadImage();
                upload.SetAllowSize = maxSize;
            }
            return Json(clientResult);
        }
    }
}