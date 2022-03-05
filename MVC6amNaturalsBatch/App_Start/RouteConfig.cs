using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC6amNaturalsBatch
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("New/GetmeView");



            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                          name: "asdfasdf",
                          url: "test/burger",
                          defaults: new { controller = "New", action = "Index", id = UrlParameter.Optional }
                      );

            routes.MapRoute(
                name: "Default234",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            
        }
    }
}
