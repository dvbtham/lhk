using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using LeHuuKhoa.Core;
using LeHuuKhoa.Core.Models;
using LeHuuKhoa.Core.Utilities;
using LeHuuKhoa.Core.Utilities.ExcelManager;
using LeHuuKhoa.Core.ViewModels;

namespace LeHuuKhoa.Areas.Administrations.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExportManager _exportManager;
        private readonly IImportManager _importManager;

        public CategoryController(IUnitOfWork unitOfWork, IImportManager importManager, IExportManager exportManager)
        {
            _unitOfWork = unitOfWork;
            _exportManager = exportManager;
            _importManager = importManager;
        }
        public ActionResult Index()
        {
            var categories = _unitOfWork.Categories.GetCategories().OrderBy(x => x.DisplayOrder);
            return View(categories);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new CategoryViewModel
            {
                Heading = "Thêm mới danh mục Luận"
            };
            return View("CategoryForm", model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(CategoryViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View("CategoryForm", viewModel);

            var category = Mapper.Map<CategoryViewModel, Category>(viewModel);

            _unitOfWork.Categories.Add(category);
            _unitOfWork.Complete();

            SetAlert($"Bạn đã thêm { viewModel.Name } thành công", "success");

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var category = _unitOfWork.Categories.Get(id);

            if (category == null) return NotFoundResult();

            var viewModel = Mapper.Map<Category, CategoryViewModel>(category);
            viewModel.Heading = "Cập nhật Danh mục Luận";
            return View("CategoryForm", viewModel);
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Update(CategoryViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("CategoryForm", viewModel);
            }
            var category = _unitOfWork.Categories.Get(viewModel.Id);
            
            if (category == null) return NotFoundResult();

            Mapper.Map(viewModel, category);

            _unitOfWork.Complete();

            SetAlert($"Bạn đã cập nhật { viewModel.Name } thành công", "success");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            var category = _unitOfWork.Categories.Get(id);
            _unitOfWork.Categories.Delete(category);
            _unitOfWork.Complete();
            return Json(category);
        }

        [HttpPost]
        public JsonResult PublisheToggle(int id)
        {
            var category = _unitOfWork.Categories.Get(id);
            category.IsPublished = !category.IsPublished;
            _unitOfWork.Complete();
            return Json("Cập nhật thành công");
        }

       
        #region Import/Export

        [HttpGet]
        public FileContentResult ExportCategories()
        {
            var categories = _unitOfWork.Categories.GetCategories().ToList();

            var bytes = _exportManager.ExportCategoriesToXlsx(categories);
            return File(bytes, MimeTypes.TextXlsx, $"danh_muc_{DateTime.Now:yyyyMMddhhmmsss}.xlsx");
        }

        [HttpPost]
        public JsonResult ImportCategories()
        {
            var file = Request.Files["importedCategories"];
            if (file == null || file.ContentLength <= 0)
                return Json(new
                {
                    message = "Đã xảy ra lỗi trong quá trình nhập liệu! Vui lòng liên hệ với nhà phát triển."
                });
            _importManager.ImportCategoriesFromXlsx(file.InputStream);

            return Json(new
            {
                message = "Nhập liệu thành công."
            });
        }

        #endregion
    }
}