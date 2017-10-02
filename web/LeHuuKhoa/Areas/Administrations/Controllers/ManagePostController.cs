using System;
using System.Linq;
using System.Web.Mvc;
using LeHuuKhoa.Core;
using LeHuuKhoa.Core.Models;
using LeHuuKhoa.Core.Utilities;
using LeHuuKhoa.Core.ViewModels;

namespace LeHuuKhoa.Areas.Administrations.Controllers
{
    public class ManagePostController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;

        public ManagePostController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ActionResult Index()
        {
            var posts = _unitOfWork.Posts.GetPosts("Category");
            return View(posts);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var viewModel = new PostViewModel();
           PrepareDropdownList(viewModel);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(PostViewModel viewModel)
        {
           PrepareDropdownList(viewModel);
            if (!ModelState.IsValid) return View(viewModel);

            var post = new Post
            {
                Id = Guid.NewGuid().ToString(),
                DateCreated = DateTime.Now,
                Views = 0,
                Slug = SlugHelper.ToUnsignString(viewModel.Title)
            };
            post.Modify(viewModel.Title, viewModel.Descriptions,
                viewModel.Content, viewModel.CategoryId,
                viewModel.MetaDescription, viewModel.MetaKeyword, viewModel.IsPopularPost);

            _unitOfWork.Posts.Add(post);

            _unitOfWork.Complete();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var post = _unitOfWork.Posts.Get(id);
            var model = new PostViewModel
            {
                Id = post.Id,
                Title = post.Title,
                Slug = post.Slug,
                CategoryId = post.CategoryId,
                Descriptions = post.Descriptions,
                Content = post.Content,
                MetaDescription = post.MetaDescription,
                MetaKeyword = post.MetaKeyword,
                IsPopularPost = post.IsPopularPost
            };
            PrepareDropdownList(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Update(PostViewModel viewModel)
        {
            PrepareDropdownList(viewModel);
            if (!ModelState.IsValid) return View("Edit", viewModel);

            var post = _unitOfWork.Posts.Get(viewModel.Id);
            post.DateUpdated = DateTime.Now;
            post.Slug = SlugHelper.ToUnsignString(viewModel.Title);
            post.Modify(viewModel.Title, viewModel.Descriptions,
                viewModel.Content, viewModel.CategoryId,
                viewModel.MetaDescription, viewModel.MetaKeyword, viewModel.IsPopularPost);

            _unitOfWork.Complete();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult Delete(PostViewModel viewModel)
        {
            var post = _unitOfWork.Posts.Get(viewModel.Id);
            _unitOfWork.Posts.Delete(post);
            _unitOfWork.Complete();
            return Json(post);
        }

        [NonAction]
        private void PrepareDropdownList(PostViewModel viewModel)
        {
            var categories = _unitOfWork.Categories.GetCategories().OrderBy(x => x.DisplayOrder);
            viewModel.CategoryList = new SelectList(categories, "Id", "Name");
        }
    }
}