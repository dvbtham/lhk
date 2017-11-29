using System.Web.Mvc;

namespace LeHuuKhoa.Areas.Administrations.Controllers
{
    [Authorize(Roles = "Admin, Mod")]
    public class BaseController : Controller
    {
        public ActionResult NotFoundResult()
        {
            return View("404");
        }

        public ActionResult IntervalErrorResult()
        {
            return View("500");
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Admin"))
                {
                    const string currentRole = "Admin";
                    Session["CKFinder_UserRole"] = currentRole;
                    return;
                }

                if (User.IsInRole("Mod"))
                {
                    const string currentRole = "Mod";
                    Session["CKFinder_UserRole"] = currentRole;
                    return;
                }
            }
           
            base.OnActionExecuting(filterContext);

        }
        
        protected void SetAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;
            switch (type)
            {
                case "success":
                    TempData["AlertType"] = "alert-success";
                    break;
                case "warning":
                    TempData["AlertType"] = "alert-warning";
                    break;
                case "error":
                    TempData["AlertType"] = "alert-error";
                    break;
                default:
                    TempData["AlertType"] = "alert-error";
                    break;
            }
        }
    }
}