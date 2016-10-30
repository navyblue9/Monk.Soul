using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Monk.Utils
{
    public class RouteHelper
    {
        public static string RouteUrl(object routeAttr, string routeName = "Services_default")
        {
            VirtualPathData vp = RouteTable.Routes.GetVirtualPath(null, routeName, new RouteValueDictionary(routeAttr));
            return vp.VirtualPath;
        }
    }
}