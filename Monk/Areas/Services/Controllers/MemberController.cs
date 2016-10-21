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

namespace Monk.Areas.Services.Controllers
{
    public class MemberController : BaseController
    {
        public MemberController(DbServices services) : base(services) { }

        [HttpPost]
        public JsonResult Signin(string account, string password)
        {
            JsonData<Member> clientResult = new JsonData<Member>() { };
            Expression<Func<Member, bool>> expression = u => u.Account == account && u.Password == password;

            services.Command((db) =>
            {
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
                            clientResult.SetClientData("y", "登录成功", member);
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