using System.Web.Mvc;
using System.Web.Routing;

namespace LeHuuKhoa
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
           
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*DocumentHandler}", new { DocumentHandler = @".*\.axd(/.*)?" });
            routes.MapRoute(
                "Detail Category",
                "danh-muc-luan/{id}.html",
                new { controller = "Category", action = "Read", id = UrlParameter.Optional },
                new[] { "LeHuuKhoa.Controllers" }
            );

            routes.MapRoute(
                "Contact",
                "lien-he.html",
                new { controller = "Home", action = "Contact", id = UrlParameter.Optional },
                new[] { "LeHuuKhoa.Controllers" }
            );

            routes.MapRoute(
                "Tac Gia",
                "trang/{id}.html",
                new { controller = "Page", action = "Read", id = UrlParameter.Optional },
                new[] { "LeHuuKhoa.Controllers" }
            );

            routes.MapRoute(
                "Login",
                "dang-nhap.html",
                new { controller = "Account", action = "Login", id = UrlParameter.Optional },
                new[] { "LeHuuKhoa.Controllers" }
            );

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "LeHuuKhoa.Controllers" }
            );
        }
    }
}
