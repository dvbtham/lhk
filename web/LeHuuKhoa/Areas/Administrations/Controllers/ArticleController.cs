using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using LeHuuKhoa.Core;
using LeHuuKhoa.Core.Models;
using LeHuuKhoa.Core.Utilities;
using LeHuuKhoa.Core.Utilities.ExcelManager;
using LeHuuKhoa.Core.ViewModels;
using Microsoft.AspNet.Identity;

namespace LeHuuKhoa.Areas.Administrations.Controllers
{
    public class ArticleController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExportManager _exportManager;
        private readonly IImportManager _importManager;

        public ArticleController(IUnitOfWork unitOfWork, IImportManager importManager, IExportManager exportManager)
        {
            _unitOfWork = unitOfWork;
            _exportManager = exportManager;
            _importManager = importManager;
        }
        public ActionResult Index()
        {
            var data = _unitOfWork.Articles.GetAll();
            return View(data);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new ArticleSaveViewModel
            {
                Heading = "Thêm mới bài viết"
            };
            PrepareDropdown(model);
            return View("ArticleForm", model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(ArticleSaveViewModel viewModel)
        {
            PrepareDropdown(viewModel);
            if (!ModelState.IsValid)
                return View("ArticleForm", viewModel);

            var article = Mapper.Map<ArticleSaveViewModel, Article>(viewModel);

            foreach (var attribute in viewModel.Attributes)
            {
                var attributeValue = new ArticleAttributeValue()
                {
                    AttributeId = attribute.Id,
                    Value = attribute.Value
                };
                article.AddAttributeValue(attributeValue);
            }

            _unitOfWork.Articles.Add(article);
            //_unitOfWork.Complete();

            SetAlert($"Bạn đã thêm { viewModel.Title } thành công", "success");

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {

            var article = _unitOfWork.Articles.Get(id);

            if (article == null) return NotFoundResult();

            var viewModel = Mapper.Map<Article, ArticleSaveViewModel>(article);
            viewModel.Heading = "Cập nhật Bài viết";
            PrepareDropdown(viewModel);
            return View("ArticleForm", viewModel);
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ArticleSaveViewModel viewModel)
        {
            PrepareDropdown(viewModel);
            if (!ModelState.IsValid)
            {
                return View("ArticleForm", viewModel);
            }
            var article = _unitOfWork.Articles.Get(viewModel.Id);

            if (article == null) return NotFoundResult();

            Mapper.Map(viewModel, article);

            _unitOfWork.Complete();

            SetAlert($"Bạn đã cập nhật { viewModel.Title } thành công", "success");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            var article = _unitOfWork.Articles.Get(id);
            _unitOfWork.Articles.Delete(article);
            _unitOfWork.Complete();
            return Json(article);
        }

        [NonAction]
        private void PrepareDropdown(ArticleSaveViewModel model)
        {
            model.ArticleGroups = new SelectList(_unitOfWork.Articles.GetArticleGroups(), "Id", "Name");
        }

        [HttpPost]
        public JsonResult PublisheToggle(int id)
        {
            var article = _unitOfWork.Categories.Get(id);
            article.IsPublished = !article.IsPublished;
            _unitOfWork.Complete();
            return Json("Cập nhật thành công");
        }

        [HttpGet]
        public JsonResult GetAttributes(int id)
        {
            var attr = _unitOfWork.Articles.GetAttributes(id);

            var result = attr.Select(x => new
            {
                Id = x.Id,
                Name = x.Name
            });
            return Json(result, JsonRequestBehavior.AllowGet);
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