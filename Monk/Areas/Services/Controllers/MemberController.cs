using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SqlSugar;
using Monk.DbStore;
using Monk.Models;
using Monk.Utils;
using SyntacticSugar;

namespace Monk.Areas.Services.Controllers
{
    public class MemberController : BaseController
    {
        public MemberController(DbServices services) : base(services) { }

        [HttpPost]
        public JsonResult Signin(string account, string password)
        {
            JsonData<Member> clientResult = new JsonData<Member>() { };
            EncryptSugar encrypt = new EncryptSugar();
            var passwordMD5 = encrypt.MD5(password).ToLower();
            Expression<Func<Member, bool>> expression = u => u.Account == account && u.Password == passwordMD5;
            var logid = Guid.NewGuid();

            services.Command((db) =>
            {
                // 登录日志
                db.Insert<LoginLog>(new LoginLog()
                {
                    LogID = logid,
                    Account = account,
                    Password = password,
                    InTime = DateTime.Now,
                    Sucessed = false,
                    IPAddress = RequestInfo.UserAddress,
                    HttpMethod = Request.HttpMethod,
                    AjaxRequest = Request.IsAjaxRequest(),
                    MobileDevice = Request.Browser.IsMobileDevice,
                    Platform = Request.Browser.Platform,
                    Browser = Request.Browser.Type,
                    LogMemberID = default(Guid)
                });

                var query = db.Queryable<Member>();
                bool any = query.Any(expression);
                if (any)
                {
                    var member = query.SingleOrDefault(expression);
                    if (!member.Enable)
                    {
                        clientResult.SetClientData("n", "该会员账号已被禁用");
                    }
                    else
                    {
                        if (!member.Pass)
                        {
                            clientResult.SetClientData("n", "该会员账号还未审核");
                        }
                        else
                        {
                            db.Update<LoginLog>(new
                            {
                                Sucessed = true,
                                member.MemberID
                            }, u => u.LogID == logid);

                            clientResult.SetClientData("y", "登录成功", member, logid);
                        }
                    }
                }
                else
                {
                    clientResult.SetClientData("n", "会员账号或密码错误");
                }
            });
            return Json(clientResult);
        }
    }
}