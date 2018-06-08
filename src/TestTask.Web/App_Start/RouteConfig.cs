using System.Web.Mvc;
using System.Web.Routing;

namespace TestTask.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",
                "{*path}",
                new { controller = "Folders", action = "Index", path = UrlParameter.Optional }
            );
        }
    }
}
