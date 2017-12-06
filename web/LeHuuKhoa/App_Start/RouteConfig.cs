using System.Web.Mvc;
using System.Web.Routing;

namespace LeHuuKhoa
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

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
                "Search",
                "tim-kiem.html",
                new { controller = "Search", action = "Index", q = UrlParameter.Optional },
                new[] { "LeHuuKhoa.Controllers" }
            );

            routes.MapRoute(
                "Download",
                "download-{fileId}",
                new { controller = "Category", action = "Download", fileId = UrlParameter.Optional },
                new[] { "LeHuuKhoa.Controllers" }
            );

            routes.MapRoute(
                "PdfPartialView",
                "xem-pdf-{postId}",
                new { controller = "Category", action = "PdfPartialView", postId = UrlParameter.Optional },
                new[] { "LeHuuKhoa.Controllers" }
            );

            routes.MapRoute(
                "ContentPartialView",
                "van-ban-{postId}",
                new { controller = "Category", action = "ContentPartialView", postId = UrlParameter.Optional },
                new[] { "LeHuuKhoa.Controllers" }
            );

            routes.MapRoute(
                "Login",
                "dang-nhap.html",
                new { controller = "Account", action = "Login", id = UrlParameter.Optional },
                new[] { "LeHuuKhoa.Controllers" }
            );

            routes.MapRoute(
                "page not found",
                "khong-tim-thay-trang.html",
                new { controller = "Error", action = "NotFound", id = UrlParameter.Optional },
                new[] { "LeHuuKhoa.Controllers" }
            );

            routes.MapRoute(
                "internal error",
                "loi-he-thong.html",
                new { controller = "Error", action = "Default", id = UrlParameter.Optional },
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
