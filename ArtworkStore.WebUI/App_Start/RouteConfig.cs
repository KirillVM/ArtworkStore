using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ArtworkStore.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                null,
                "",
                new { controller = "Artwork", action = "List", technique = (string)null, page = 1 }
            );

            routes.MapRoute(
                name: null,
                url: "Page{page}",
                defaults: new { controller = "Artwork", action = "List", technique = (string)null},
                constraints: new {page = @"\d+"}
            );

            routes.MapRoute(
                null,
                "{technique}",
                new { controller = "Artwork", action = "List", page = 1 }
            );

            routes.MapRoute(
                null,
                "{technique}/Page{page}",
                new { controller = "Artwork", action = "List" },
                new { page = @"\d+" }
            );

            routes.MapRoute(null, "{controller}/{action}");
        }
    }
}
