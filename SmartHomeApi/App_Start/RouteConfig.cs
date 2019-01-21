using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SmartHomeApi
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{action}",
                defaults: new { controller = "Home", action = "Index"}
            );

            routes.MapRoute(
                name: "HomeApi",
                url: "Homes/{id}/data",
                defaults: new { controller = "Home", action = "GetHome"}
            );
        }
    }
}
