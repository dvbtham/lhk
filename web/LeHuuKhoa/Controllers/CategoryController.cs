﻿using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using LeHuuKhoa.Core;
using LeHuuKhoa.Core.Models;
using LeHuuKhoa.Core.ViewModels;

namespace LeHuuKhoa.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Read(string id)
        {
            var category = _unitOfWork.Categories.Get(id, include: true);
            var categoryVm = Mapper.Map<PostCategory, PostCategoryClientViewModel>(category);
            return View(categoryVm);
        }

        [ChildActionOnly]
        public ActionResult Categories()
        {
            var categories = _unitOfWork.Categories.GetCategories().OrderBy(x => x.DisplayOrder);
            return PartialView("_CategoryLeftSidePartial", categories);
        }

        public ActionResult PdfPartialView(long postId)
        {
            var pdfVm = new PdfViewModel();
            var postFiles = _unitOfWork.PostFiles.GetPostFiles(postId, includeFile: true);

            foreach (var item in postFiles)
            {
                pdfVm.FileName.Add(item.File.Name);
            }

            return View(pdfVm);
        }
        public ActionResult ContentPartialView(long postId)
        {
            var post = _unitOfWork.Posts.Get(postId);
            var contentVm = new ContentViewModel { Content = post.Content };
            return View(contentVm);
        }

        public ActionResult SlideContentPartialView(long postId)
        {
            var post = _unitOfWork.Posts.Get(postId);
            var slideVm = new SlideViewModel();
            var images = post.Images.Split('|');
            foreach (var path in images)
            {
                if (!string.IsNullOrEmpty(path))
                    slideVm.ImagesPath.Add(path);
            }
            return View(slideVm);
        }
    }
}