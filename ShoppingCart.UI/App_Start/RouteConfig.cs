using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ShoppingCart.UI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                null,
                "",
                defaults: new { controller = "Home", action = "Index", categoryLinkText = (string)null, page = 1 }
            );

            routes.MapRoute(null,
            "{page}",
            new { controller = "Home", action = "Index", categoryLinkText = (string)null },
            new { page = @"\d+" }
            );

            routes.MapRoute(null,
            "{categoryLinkText}",
            new { controller = "Home", action = "Index", page = 1 }
            );

            routes.MapRoute(null,
            "{categoryLinkText}/{page}",
            new { controller = "Home", action = "Index" },
            new { page = @"\d+" }
            );



            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
