using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using LeHuuKhoa.Core;
using LeHuuKhoa.Core.Models;
using LeHuuKhoa.Core.ViewModels;
using Microsoft.AspNet.Identity;

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
            var posts = _unitOfWork.Posts.GetAllWithRelated();
            return View(posts);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var viewModel = new PostViewModel ();
            PrepareDropdownList(viewModel);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(PostViewModel viewModel, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid) 
            {
                PrepareDropdownList(viewModel);
                return View(viewModel);
            }

            var post = new Post();
            Mapper.Map(viewModel, post);
            post.AuthorId = User.Identity.GetUserId();

            try
            {
                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/user-content"), fileName ?? throw new InvalidOperationException());
                    file.SaveAs(path);
                    var fileSave = new Core.Models.File
                    {
                        Name = fileName,
                        FileSize = file.ContentLength,
                        FileType = FileType.Document
                    };
                    _unitOfWork.Files.Add(fileSave);
                    _unitOfWork.Complete();
                    _unitOfWork.PostFiles.Add(post.Id, fileSave.Id);
                }
            }
            catch
            {
                SetAlert("File upload failed!!", "error");
                PrepareDropdownList(viewModel);
                return View(viewModel);
            }

            _unitOfWork.Posts.Add(post);
            _unitOfWork.Complete();

            SetAlert($"Thêm { post.Title } thành công.", "success");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            var post = _unitOfWork.Posts.Get(id);
            if (post == null) return NotFoundResult();
            var postVm = new PostViewModel();

            Mapper.Map(post, postVm);

            PrepareDropdownList(postVm);
            return View(postVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Update(PostViewModel viewModel, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                PrepareDropdownList(viewModel);
                return View("Edit", viewModel);
            }

            var post = _unitOfWork.Posts.Get(viewModel.Id);

            if (post == null) return NotFoundResult();

            Mapper.Map(viewModel, post);
            post.CategoryId = viewModel.CategoryId;
            post.DateUpdated = DateTime.Now;
            post.AuthorId = User.Identity.GetUserId();

            _unitOfWork.Complete();
            SetAlert($"Cập nhật { post.Title } thành công.", "success");
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
            viewModel.Categories = new SelectList(categories, "Id", "Name");
        }
    }
}