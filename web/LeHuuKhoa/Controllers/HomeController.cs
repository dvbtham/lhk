using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using LeHuuKhoa.Core;
using LeHuuKhoa.Core.Models;
using LeHuuKhoa.Core.Utilities;
using LeHuuKhoa.Core.ViewModels;

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
            var categories = _unitOfWork.Categories.GetCategories(checkPublished: true).OrderBy(x => x.DisplayOrder);
            return View(categories);
        }

        public ActionResult StartPageHeader()
        {
            var page = _unitOfWork.Pages.Get(Constants.DefaultPage);
            var viewModel = Mapper.Map<Page, PageViewModel>(page);
            return PartialView("_StartPageHeader", viewModel);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult RenderMenu()
        {
            var menus = _unitOfWork.Menus.GetMenus();
            var viewModel = Mapper.Map<IEnumerable<Menu>, IEnumerable<MenuViewModel>>(menus);
            return PartialView("_Menu", viewModel);
        }
    }
}