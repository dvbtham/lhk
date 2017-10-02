using System.Web.Mvc;

namespace LeHuuKhoa.Areas.Administrations.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BaseController : Controller
    {
        protected void SetAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;
            switch (type)
            {
                case "success":
                    ViewData["AlertType"] = "alert-success";
                    break;
                case "warning":
                    ViewData["AlertType"] = "alert-warning";
                    break;
                case "error":
                    ViewData["AlertType"] = "alert-error";
                    break;
            }
        }
    }
}