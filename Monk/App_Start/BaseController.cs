using System.Web.Mvc;
using Monk.DbStore;

namespace Monk
{
    public class BaseController : Controller
    {
        protected DbServices _services;
        public BaseController(DbServices services)
        {
            _services = services;
        }
    }
}