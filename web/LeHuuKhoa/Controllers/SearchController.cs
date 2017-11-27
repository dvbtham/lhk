using System.Linq;
using System.Web.Mvc;
using LeHuuKhoa.Core;

namespace LeHuuKhoa.Controllers
{
    public class SearchController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SearchController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult Index(string q)
        {
            ViewBag.SearchKeyword = q;
            var result = _unitOfWork.Posts.GetPosts().Where(x => x.Title.ToLower().Contains(q.ToLower()));
                
            return View(result);
        }
    }
}