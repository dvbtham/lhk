using System;
using System.Linq;
using System.Web.Mvc;
using LeHuuKhoa.Core;

namespace LeHuuKhoa.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ActionResult Index()
        {
            var categories = _unitOfWork.Categories.GetCategories().OrderBy(x => x.DisplayOrder);
            return View(categories);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}