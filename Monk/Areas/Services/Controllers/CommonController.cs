using System.Web.Mvc;
using System.IO;
using Monk.Utils;
using Monk.ViewModels;
using System;

namespace Monk.Areas.Services.Controllers
{
    public class CommonController : Controller
    {
        [HttpPost]
        public JsonResult UploadImage()
        {
            var clientResult = new JsonData<object>() { };
            var setVewModel = RouteData.DataTokens[Keys.SysSetInfoInjectionKey] as SysSetViewModel;

            if (setVewModel == null) clientResult.SetClientData("n", "非法操作");
            else
            {
                var area = Request.Form["area"];
                var controller = Request.Form["controller"];
                var supportExt = ".jpeg|.jpg|.bmp|.gif|.png";
                var maxSize = setVewModel.ImageMaxSize;
                var file = Request.Files[0];
                var size = file.ContentLength / 1024.0 / 1024.0;
                var ext = Path.GetExtension(file.FileName);
                if (size > maxSize) clientResult.SetClientData("n", "上传的图片大小超出限制大小：" + maxSize + " M");
                else
                {
                    var datetime = DateTime.Now;
                    var root = "/Areas/" + area + "/Assets/Users/" + controller + "/" + datetime.Year + "-" + datetime.Month + "-" + datetime.Day + "/";
                    var newName = Guid.NewGuid() + ext;
                    string realpath = Server.MapPath(root);
                    if (!Directory.Exists(realpath)) Directory.CreateDirectory(realpath);
                    if (!FileHelper.CheckValidExt(supportExt, ext)) clientResult.SetClientData("n", "不支持该图片类型，目前只支持：" + supportExt + " 类型");
                    else
                    {
                        file.SaveAs(realpath + newName);
                        clientResult.SetClientData("y", "上传成功", new { path = root + newName, size = size, ext = ext, source = file.FileName });
                    }
                }
            }
            return Json(clientResult);
        }
    }
}