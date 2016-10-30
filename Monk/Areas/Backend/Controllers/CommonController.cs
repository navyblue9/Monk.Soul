using System;
using System.Linq;
using System.Web.Mvc;
using System.Linq.Expressions;
using SqlSugar;
using AutoMapper;
using Monk.Models;
using Monk.Areas.Backend.ViewModels;
using Monk.DbStore;
using Monk.Utils;
using Monk.Filters;
using System.IO;

namespace Monk.Areas.Backend.Controllers
{
    public class CommonController : BaseController
    {
        public CommonController(DbServices services) : base(services) { }

        [HttpPost]
        [Anonymous]
        public JsonResult Signin(SigninVM viewModel)
        {
            var clientResult = new JsonData<MemberSessionVM>() { };
            var encryptPassword = viewModel.Password.Trim().ToMD5();
            var loginLogId = Guid.NewGuid();

            services.Command((db) =>
            {
                db.Insert<LoginLog>(new LoginLog()
                {
                    LogID = loginLogId,
                    Account = viewModel.Account.Trim(),
                    Password = StringHelper.EncryptPassword(viewModel.Password),
                    InTime = DateTime.Now,
                    Sucessed = false,
                    IPAddress = RequestHelper.IPAddress,
                    HttpMethod = Request.HttpMethod,
                    AjaxRequest = Request.IsAjaxRequest(),
                    MobileDevice = Request.Browser.IsMobileDevice,
                    Platform = Request.Browser.Platform,
                    Browser = Request.Browser.Type,
                    LogMemberID = default(Guid)
                });

                var query = db.Queryable<Member>();
                Expression<Func<Member, bool>> whereExpr = u => u.Account == viewModel.Account.Trim() && u.Password == encryptPassword;
                bool exit = query.Any(whereExpr);
                if (exit)
                {
                    var member = query.SingleOrDefault(whereExpr);
                    if (member.Enable && member.Pass)
                    {
                        db.Update<LoginLog>(new { Sucessed = true, member.MemberID }, u => u.LogID == loginLogId);
                        Mapper.Initialize(c => c.CreateMap<Member, MemberSessionVM>());
                        var memberVM = Mapper.Map<MemberSessionVM>(member);
                        Session[Keys.SessionKey] = memberVM;
                        clientResult.SetClientData("y", "登录成功", memberVM);
                    }
                    if (!member.Enable) clientResult.SetClientData("n", "该账号已被禁用");
                    if (!member.Pass) clientResult.SetClientData("n", "该账号还在审核中");
                }
                else clientResult.SetClientData("n", "账号或密码错误");
            });

            return Json(clientResult);
        }

        [HttpPost]
        public JsonResult Signout()
        {
            var clientResult = new JsonData<object>() { };
            var sessionMember = SessionHelper.GetSessionInstance<MemberSessionVM>(Keys.SessionKey);
            services.Command((db) =>
            {
                db.Update<LoginLog>(new { OffTime = DateTime.Now, UpdateTime = DateTime.Now }, u => u.LogID == sessionMember.LogID);
                clientResult.SetClientData("y", "注销成功");
            });
            Session[Keys.SessionKey] = null;
            return Json(clientResult);
        }

        [HttpPost]
        public JsonResult UploadImage()
        {
            var clientResult = new JsonData<object>() { };
            var setVewModel = RouteData.DataTokens[Keys.SysSetInfoInjectionKey] as SysSetVM;

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