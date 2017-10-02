using System.Web.Mvc;

namespace LeHuuKhoa.Areas.Administrations
{
    public class AdministrationsAreaRegistration : AreaRegistration 
    {
        public override string AreaName => "Administrations";

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Administrations_default",
                "Administrations/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new[] { "LeHuuKhoa.Areas.Administrations.Controllers" }
            );
        }
    }
}