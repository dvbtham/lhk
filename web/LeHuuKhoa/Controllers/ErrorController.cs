using System.Web.Mvc;

namespace LeHuuKhoa.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult NotFound()
        {
            return View("404");
        }
        public ActionResult Default()
        {
            return View("Error");
        }
    }
}