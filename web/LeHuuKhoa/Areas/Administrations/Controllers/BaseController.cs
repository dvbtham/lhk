using System.Web.Mvc;
using LeHuuKhoa.Core;
using Microsoft.AspNet.Identity;

namespace LeHuuKhoa.Areas.Administrations.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BaseController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BaseController()
        {
            _unitOfWork = ServiceFactory.Get<IUnitOfWork>();
        }

        protected ActionResult NotFoundResult()
        {
            return View("404");
        }

        protected ActionResult IntervalErrorResult()
        {
            return View("500");
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var userId = User.Identity.GetUserId();
            ViewData["UserAvatar"] = _unitOfWork.ApplicationUsers.Get(userId).ImageUrl;
            ViewData["Name"] = _unitOfWork.ApplicationUsers.Get(userId).Name;
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
            }
        }
    }
}