using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            // ATTRIBUTE WAY OF ROUTING
            // [Route("record/sortBy/{year}/{month:regex(\\d{4}):range(1,12)}")]

            routes.MapRoute(
                name: "sortByDate",
                url: "record/sortBy/{year}/{month}",
                defaults: new { controller = "Record", action = "ByMessagedDate" },
                          new { year = @"\d{4}", month = @"\d{2}" }
                ) ;
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Main",
                url: "main",
                defaults: new { controller = "Main", action = "Index" }
            );
        }
    }
}
