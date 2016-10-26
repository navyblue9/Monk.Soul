﻿using System;
using System.Linq.Expressions;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using SqlSugar;
using Monk.DbStore;
using Monk.Models;
using Monk.ViewModels;
using Monk.Utils;

namespace Monk.Areas.Services.Controllers
{
    public class MemberController : BaseController
    {
        public MemberController(DbServices services) : base(services) { }

        [HttpPost]
        public JsonResult Signin(string account, string password)
        {
            var clientResult = new JsonData<MemberViewModel>() { };
            var passwordMD5 = password.ToMD5().ToLower();
            Expression<Func<Member, bool>> expression = u => u.Account == account && u.Password == passwordMD5;
            var logid = Guid.NewGuid();

            services.Command((db) =>
            {
                // 登录日志
                db.Insert<LoginLog>(new LoginLog()
                {
                    LogID = logid,
                    Account = account,
                    Password = StringHelper.EncryptPassword(password),
                    InTime = DateTime.Now,
                    Sucessed = false,
                    IPAddress = RequestHelper.UserAddress,
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

                            // 此地方需要重点优化，后期使用autofac统一注入
                            Mapper.Initialize(c => c.CreateMap<Member, MemberViewModel>());

                            clientResult.SetClientData("y", "登录成功", Mapper.Map<MemberViewModel>(member), logid);
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

        [HttpPost]
        public JsonResult Signout(Guid logid)
        {
            var clientResult = new JsonData<object>() { };
            services.Command((db) =>
            {
                db.Update<LoginLog>(new
                {
                    OffTime = DateTime.Now,
                    UpdateTime = DateTime.Now
                }, u => u.LogID == logid);

                clientResult.SetClientData("y", "注销成功");
            });
            return Json(clientResult);
        }
    }
}