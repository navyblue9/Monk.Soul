﻿using System.Web.Mvc;

namespace Monk.Areas.Backend
{
    public class BackendAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Backend";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Backend_default",
                "Backend/{controller}/{action}/{id}",
                new { action = "Signin", controller = "Default", id = UrlParameter.Optional },
                new string[] { "Monk.Areas.Backend.Controllers" }
            );
        }
    }
}