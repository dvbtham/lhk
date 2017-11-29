using System.Linq;
using System.Web.Mvc;

namespace LeHuuKhoa.Areas.Administrations
{
    public class AdminAuthorize : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
            else if (!Roles.Split(',').Any(filterContext.HttpContext.User.IsInRole))
            {
                filterContext.Result = new ViewResult
                {
                    ViewName = "~/Areas/Administrations/Views/Shared/UnAuthorized.cshtml"
                };
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }
    }
}