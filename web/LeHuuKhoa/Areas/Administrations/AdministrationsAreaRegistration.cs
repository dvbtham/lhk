using System.Web.Mvc;

namespace LeHuuKhoa.Areas.Administrations
{
    public class AdministrationsAreaRegistration : AreaRegistration 
    {
        public override string AreaName => "Administrations";

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "dashboard",
                "quan-ly/trang-chu.html",
                new { action = "Index", controller= "DashBoard", area = "Administrations", id = UrlParameter.Optional },
                new[] { "LeHuuKhoa.Areas.Administrations.Controllers" }
            );

            context.MapRoute(
                "post",
                "quan-ly/bai-viet.html",
                new { action = "Index", controller = "ManagePost", area = "Administrations", id = UrlParameter.Optional },
                new[] { "LeHuuKhoa.Areas.Administrations.Controllers" }
            );

            context.MapRoute(
                "category",
                "quan-ly/danh-muc.html",
                new { action = "Index", controller = "PostCategory", area = "Administrations", id = UrlParameter.Optional },
                new[] { "LeHuuKhoa.Areas.Administrations.Controllers" }
            );

            context.MapRoute(
                "pages",
                "quan-ly/trang.html",
                new { action = "Index", controller = "Page", area = "Administrations", id = UrlParameter.Optional },
                new[] { "LeHuuKhoa.Areas.Administrations.Controllers" }
            );

            context.MapRoute(
                "Edit page",
                "quan-ly/trang/{id}.html",
                new { action = "Edit", controller = "Page", area = "Administrations", id = UrlParameter.Optional },
                new[] { "LeHuuKhoa.Areas.Administrations.Controllers" }
            );

            context.MapRoute(
                "Create page",
                "quan-ly/them-trang.html",
                new { action = "Create", controller = "Page", area = "Administrations", id = UrlParameter.Optional },
                new[] { "LeHuuKhoa.Areas.Administrations.Controllers" }
            );

            context.MapRoute(
                "edit category",
                "quan-ly/danh-muc/{id}.html",
                new { action = "Edit", controller = "PostCategory", area = "Administrations", id = UrlParameter.Optional },
                new[] { "LeHuuKhoa.Areas.Administrations.Controllers" }
            );

            context.MapRoute(
                "add category",
                "quan-ly/them-danh-muc.html",
                new { action = "Create", controller = "PostCategory", area = "Administrations", id = UrlParameter.Optional },
                new[] { "LeHuuKhoa.Areas.Administrations.Controllers" }
            );

            context.MapRoute(
                "Administrations_default",
                "Administrations/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new[] { "LeHuuKhoa.Areas.Administrations.Controllers" }
            );
        }
    }
}