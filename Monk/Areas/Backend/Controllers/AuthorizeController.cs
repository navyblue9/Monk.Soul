using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SqlSugar;
using Monk.DbStore;
using Monk.Models;

namespace Monk.Areas.Backend.Controllers
{
    public class AuthorizeController : BaseController
    {
        public AuthorizeController(DbServices services) : base(services) { }

        public JsonResult Index()
        {
            List<Havior> list = new List<Havior>();
            _services.Command((db) =>
            {
                list = db.Queryable<Havior>().Where(c => true).ToList();
            });
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}