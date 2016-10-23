using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Monk.Utils
{
    public class SessionHelper
    {
        public static T GetSessionInstance<T>(string sessionKey) where T : class, new()
        {
            return HttpContext.Current.Session[sessionKey] as T;
        }
    }
}