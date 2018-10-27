using System.Web.Mvc;
using System.Web.Routing;

namespace Dayboi_Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
            name: "Category",
            url: "shop/{categoryId}/{alias}",
            defaults: new { controller = "Shop", action = "Index", categoryId = UrlParameter.Optional },
            namespaces: new string[] { "Dayboi_Web.Controllers" }
            );

            routes.MapRoute(
           name: "Product",
           url: "product/{productId}/{alias}",
           defaults: new { controller = "Shop", action = "Product", productId = UrlParameter.Optional },
           namespaces: new string[] { "Dayboi_Web.Controllers" }
           );


            routes.MapRoute(
        name: "Blog",
        url: "blog/{blogId}/{alias}",
        defaults: new { controller = "Blog", action = "BlogDetail", blogId = UrlParameter.Optional },
        namespaces: new string[] { "Dayboi_Web.Controllers" }
        );

            routes.MapRoute(
       name: "Course",
       url: "khoa-hoc/{courseId}/{alias}",
       defaults: new { controller = "Course", action = "CourseDetail", courseId = UrlParameter.Optional },
       namespaces: new string[] { "Dayboi_Web.Controllers" }
       );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


        }
    }
}