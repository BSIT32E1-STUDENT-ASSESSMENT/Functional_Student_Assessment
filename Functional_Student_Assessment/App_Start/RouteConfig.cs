using Microsoft.Data.SqlClient;
using System.Web.Mvc;
using System.Web.Routing;

namespace YourNamespace // Replace with your project's namespace
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Teacher", action = "InputGrades", id = UrlParameter.Optional }
            );
        }
    }
}
