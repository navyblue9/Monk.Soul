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

        public RequestContext RequestContext { get; private set; }
        public RouteCollection RouteCollection { get; private set; }
        public RouteHelper(RequestContext requestContext)
        {
            this.RequestContext = requestContext;
            this.RouteCollection = RouteTable.Routes;
        }

        public string Action(string actionName)
        {
            return this.Action(actionName, null, null, null, null);
        }
        public string Action(string actionName, object routeValues)
        {
            return this.Action(actionName, null,
                new RouteValueDictionary(routeValues), null, null);
        }
        public string Action(string actionName, string controllerName)
        {
            return this.Action(actionName, controllerName, null, null, null);
        }
        public string Action(string actionName, RouteValueDictionary routeValues)
        {
            return this.Action(actionName, null, routeValues, null, null);
        }
        public string Action(string actionName, string controllerName, object routeValues)
        {
            return this.Action(actionName, controllerName, new RouteValueDictionary(routeValues), null, null);
        }
        public string Action(string actionName, string controllerName, RouteValueDictionary routeValues)
        {
            return this.Action(actionName, controllerName, routeValues, null, null);
        }
        public string Action(string actionName, string controllerName, object routeValues, string protocol)
        {
            return this.Action(actionName, controllerName, new RouteValueDictionary(routeValues), protocol, null);
        }
        public string Action(string actionName, string controllerName, RouteValueDictionary routeValues, string protocol, string hostName)
        {
            controllerName = controllerName ?? (string)this.RequestContext.RouteData.Values["controller"];
            routeValues = routeValues ?? new RouteValueDictionary();
            routeValues.Add("action", actionName);
            routeValues.Add("controller", controllerName);
            string virtualPath = this.RouteCollection.GetVirtualPath(this.RequestContext, routeValues).VirtualPath;
            if (string.IsNullOrEmpty(protocol) && string.IsNullOrEmpty(hostName))
            {
                return virtualPath.ToLower();
            }

            protocol = protocol ?? "http";
            Uri uri = this.RequestContext.HttpContext.Request.Url;
            hostName = hostName ?? uri.Host + ":" + uri.Port;
            return string.Format("{0}://{1}{2}", protocol, hostName, virtualPath).ToLower();
        }
    }
}