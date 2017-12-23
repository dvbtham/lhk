using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using LeHuuKhoa.Core;
using LeHuuKhoa.Core.Models;
using LeHuuKhoa.Core.Utilities;
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
            var viewCounter = (List<ViewCounterViewModel>)Session[Constants.ViewCounterSession];
            IncreaseView(viewCounter, postId);
            return View(pdfVm);
        }
        public ActionResult ContentPartialView(long postId)
        {
            var post = _unitOfWork.Posts.Get(postId);
            var contentVm = new ContentViewModel { Content = post.Content };
            var viewCounter = (List<ViewCounterViewModel>)Session[Constants.ViewCounterSession];
            IncreaseView(viewCounter, postId);
            return View(contentVm);
        }

        public FileResult Download(string fileId)
        {
            var contentType = string.Empty;
            var file = _unitOfWork.FileDownLoads.Get(fileId);
            if (file == null) return null;

            if (file.Name.Contains(".pdf"))
            {
                contentType = "application/pdf";
            }

            else if (file.Name.Contains(".docx"))
            {
                contentType = "application/docx";
            }
            return File(Path.Combine(Server.MapPath("~/Content"), file.Name), contentType, file.Name);
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
            slideVm.ImagesPath = slideVm.ImagesPath.Distinct().ToList();
            var viewCounter = (List<ViewCounterViewModel>)Session[Constants.ViewCounterSession];
            IncreaseView(viewCounter, postId);
            return PartialView("CarouselPartialView", slideVm);
        }

        public ActionResult FileDownLoadPartialView(long postId)
        {
            var post = _unitOfWork.Posts.Get(postId, include: true);
            var viewModel = new DownLoadViewModel
            {
                Post = post
            };
            return PartialView(viewModel);
        }

        #region ViewCount Helper

        private void IncreaseView(List<ViewCounterViewModel> viewCounterViewModel, long postId)
        {
            if (viewCounterViewModel != null)
            {
                if (viewCounterViewModel.All(x => x.PostId != postId))
                {
                    _unitOfWork.Posts.IncreaseView(postId);
                    AddViewCounter(postId);
                }
            }
            else
            {
                viewCounterViewModel = new List<ViewCounterViewModel>();
                _unitOfWork.Posts.IncreaseView(postId);
                AddViewCounter(postId);
            }
            _unitOfWork.Complete();
        }

        private void AddViewCounter(long productId)
        {
            var viewCounterViewModel = (List<ViewCounterViewModel>)Session[Constants.ViewCounterSession] ?? new List<ViewCounterViewModel>();
            var viewCounterVm = new ViewCounterViewModel {PostId = productId};
            viewCounterViewModel.Add(viewCounterVm);
            Session[Constants.ViewCounterSession] = viewCounterViewModel;
        }

        #endregion
    }
}