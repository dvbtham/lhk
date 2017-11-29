using System.Web.Mvc;
using LeHuuKhoa.Core;

namespace LeHuuKhoa.Controllers
{
    public class PageController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PageController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ActionResult Read(string id)
        {
            var page = _unitOfWork.Pages.Get(id);
            
            return View(page);
        }
    }
}