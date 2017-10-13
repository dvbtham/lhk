using System.Web.Mvc;
using AutoMapper;
using LeHuuKhoa.Core;
using LeHuuKhoa.Core.Models;
using LeHuuKhoa.Core.ViewModels;
using System.Linq;

namespace LeHuuKhoa.Areas.Administrations.Controllers
{
    public class MenuController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        public MenuController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public ActionResult Index()
        {
            var menus = _unitOfWork.Menus.GetMenusRelated();
            return View(menus);
        }

        public ActionResult Create()
        {
            var viewModel = new MenuViewModel
            {
                Heading = "Thêm mới menu",
                PageList = _unitOfWork.Pages.GetPages()
            };
            return View("MenuForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MenuViewModel viewModel)
        {
            if (!ModelState.IsValid) return View("MenuForm", viewModel);

            if (viewModel.PagesId != null)
            {
                var pagesId = viewModel.PagesId.Split(',');
                foreach (var id in pagesId)
                    viewModel.Pages.Add(id);
            }

            var menu = Mapper.Map<MenuViewModel, Menu>(viewModel);

            _unitOfWork.Menus.Add(menu);
            _unitOfWork.Complete();
            SetAlert("Thêm Menu thành công", "success");
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var menu = _unitOfWork.Menus.GetRelated(id);
            if (menu == null) return NotFoundResult();
            var menuViewModel = Mapper.Map<Menu, MenuViewModel>(menu);
            menuViewModel.Id = menu.Id;
            menuViewModel.Heading = "Cập nhật menu " + menu.Name;
            menuViewModel.PageList = _unitOfWork.Pages.GetPages();
            var hasPages = menu.MenuPages.Select(x=>x.Page).AsEnumerable();
            menuViewModel.Pages = hasPages.Select(x => x.Id).ToList();

            foreach (var pageid in menuViewModel.Pages)
                menuViewModel.PagesId += pageid + ",";
            return View("MenuForm", menuViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(MenuViewModel viewModel)
        {
            if (!ModelState.IsValid) return View("MenuForm", viewModel);
            var menu = _unitOfWork.Menus.GetRelated(viewModel.Id);

            if (viewModel.PagesId != null)
            {
                var pagesId = viewModel.PagesId.Split(',');
                foreach (var id in pagesId)
                    if (id != string.Empty)
                        viewModel.Pages.Add(id);
            }

            Mapper.Map(viewModel, menu);

            _unitOfWork.Complete();
            SetAlert("Cập nhật Menu thành công", "success");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            var menu = _unitOfWork.Menus.Get(id);
            if (menu == null) return Json("404");

            _unitOfWork.Menus.Delete(menu);
            _unitOfWork.Complete();

            return Json("Xóa thành công!");
        }
    }
}