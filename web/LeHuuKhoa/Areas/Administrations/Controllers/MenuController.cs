using System.Web.Mvc;
using AutoMapper;
using LeHuuKhoa.Core;
using LeHuuKhoa.Core.Models;
using LeHuuKhoa.Core.ViewModels;

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
            var menus = _unitOfWork.Menus.GetMenus();
            return View(menus);
        }

        public ActionResult Create()
        {
            var viewModel = new MenuViewModel
            {
                Heading = "Thêm mới menu",
                Pages = new SelectList(_unitOfWork.Pages.GetPages(), "Id", "Name")
            };
            return View("MenuForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MenuViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Heading = "Thêm mới menu";
                PrepareDropdownListForMenu(viewModel);
                return View("MenuForm", viewModel);
            }

            var menu = Mapper.Map<MenuViewModel, Menu>(viewModel);

            _unitOfWork.Menus.Add(menu);
            _unitOfWork.Complete();
            SetAlert("Thêm Menu thành công", "success");
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var menu = _unitOfWork.Menus.Get(id);
            if (menu == null) return NotFoundResult();

            var menuViewModel = Mapper.Map<Menu, MenuViewModel>(menu);
            menuViewModel.Id = menu.Id;
            menuViewModel.Heading = "Cập nhật menu " + menu.Name;
            PrepareDropdownListForMenu(menuViewModel);
            return View("MenuForm", menuViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(MenuViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Heading = "Thêm mới menu";
                PrepareDropdownListForMenu(viewModel);
                return View("MenuForm", viewModel);
            }
            var menu = _unitOfWork.Menus.Get(viewModel.Id);

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

        [NonAction]
        private void PrepareDropdownListForMenu(MenuViewModel viewModel)
        {
            viewModel.Pages = new SelectList(_unitOfWork.Pages.GetPages(), "Id", "Name");
        }
    }
}