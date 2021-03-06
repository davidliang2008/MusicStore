﻿using System.Web.Mvc;

namespace DL.MusicStore.Web.Mvc.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { controller = "dashboard", action = "index", id = UrlParameter.Optional }
            );

            context.Routes.LowercaseUrls = true;
        }
    }
}