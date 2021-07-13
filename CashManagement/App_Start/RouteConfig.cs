using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CashManagement
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
             name: "Default",
             url: "{controller}/{action}/{id}",
             defaults: new { controller = "AdminLogin", action = "Index", id = UrlParameter.Optional }
         );

            routes.MapRoute(
                name: "Custom",
                url: "{controller}/{action}/{id}/{id1}/{id2}/{id3}/{id4}/{id5}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, id1 = UrlParameter.Optional, id2 = UrlParameter.Optional, id3 = UrlParameter.Optional, id4 = UrlParameter.Optional, id5 = UrlParameter.Optional }
            );
        }
    }
}
