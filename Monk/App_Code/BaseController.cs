using System.Web.Mvc;
using Monk.DbStore;

namespace Monk
{
    public class BaseController : Controller
    {
        protected DbServices services;
        public BaseController(DbServices services)
        {
            this.services = services;
        }
    }
}