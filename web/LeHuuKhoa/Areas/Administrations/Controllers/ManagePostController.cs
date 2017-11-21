using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using LeHuuKhoa.Core;
using LeHuuKhoa.Core.Models;
using LeHuuKhoa.Core.Utilities;
using LeHuuKhoa.Core.ViewModels;
using Microsoft.AspNet.Identity;
using Constants = LeHuuKhoa.Core.Utilities.Constants;

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
            var viewModel = new PostViewModel();
            PrepareDropdownList(viewModel);
            ApplyPostType(viewModel);
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
                ApplyPostType(viewModel);
                return View(viewModel);
            }

            var post = new Post();
            Mapper.Map(viewModel, post);
            post.AuthorId = User.Identity.GetUserId();

            try
            {
                if (file != null && file.ContentLength > 0)
                {
                    if (file.ContentLength > Constants.MaxBytes)
                    {
                        SetAlert("Dung lượng file quá lớn so với yêu cầu! Vui lòng chọn file nhỏ hơn 25 mb.", "error");
                        return View(viewModel);
                    }
                    if (Constants.AcceptedDocType.All(f => f.ToLower() != Path.GetExtension(file.FileName)?.ToLower()))
                    {
                        PrepareDropdownList(viewModel);
                        ApplyPostType(viewModel);
                        SetAlert("Không hỗ trợ loại file này! Vui lòng chọn file .pdf hoặc .pptx.", "error");
                        return View("Edit", viewModel);
                    }
                    var fileName = Path.GetFileName(file.FileName) ?? "file_" + DateTime.Now.ToString("yyyyMMddhhmmsss");
                    var files = _unitOfWork.Files.GetFiles();
                    if (files.Any(x => string.Equals(x.Name.ToLower(), fileName.ToLower(), StringComparison.Ordinal)))
                    {
                        DeleteFile(fileName);
                    }

                   SaveFile(fileName, file);

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
            catch(Exception ex)
            {
                SetAlert("Tải tệp lên không thành công!!\t" + ex.Message, "error");
                PrepareDropdownList(viewModel);
                ApplyPostType(viewModel);
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
            ApplyPostType(postVm);
            return View(postVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Update(PostViewModel viewModel, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                ApplyPostType(viewModel);
                PrepareDropdownList(viewModel);
                return View("Edit", viewModel);
            }
            var post = _unitOfWork.Posts.Get(viewModel.Id);

            var postFile = new PostFile();

            if (post == null) return NotFoundResult();

            try
            {
                if (file != null && file.ContentLength > 0)
                {
                    if (file.ContentLength > Constants.MaxBytes)
                    {
                        ApplyPostType(viewModel);
                        PrepareDropdownList(viewModel);
                        SetAlert("Dung lượng file quá lớn so với yêu cầu! Vui lòng chọn file nhỏ hơn 25 mb.", "error");
                        return View("Edit", viewModel);
                    }

                    if (Constants.AcceptedDocType.All(f => f.ToLower() != Path.GetExtension(file.FileName)?.ToLower()))
                    {
                        ApplyPostType(viewModel);
                        PrepareDropdownList(viewModel);
                        SetAlert("Không hỗ trợ loại file này! Vui lòng chọn file .pdf hoặc .pptx.", "error");
                        return View("Edit", viewModel);
                    }

                    var postFileToDelete = _unitOfWork.PostFiles.GetPostFiles(post.Id);
                    foreach (var item in postFileToDelete)
                    {
                        _unitOfWork.PostFiles.Delete(item);
                        _unitOfWork.Complete();
                    }

                    var files = _unitOfWork.Files.GetFiles();
                    
                    var fileName = Path.GetFileName(file.FileName) ?? "file_"+ DateTime.Now.ToString("yyyyMMddhhmmsss");
                    if (files.Any(x => string.Equals(x.Name.ToLower(), fileName.ToLower(), StringComparison.Ordinal)))
                    {
                        DeleteFile(fileName);
                    }

                   SaveFile(fileName, file);

                    var fileSave = new Core.Models.File
                    {
                        Name = fileName,
                        FileSize = file.ContentLength,
                        FileType = FileType.Document
                    };

                    _unitOfWork.Files.Add(fileSave);
                    _unitOfWork.Complete();
                    postFile.FileId = fileSave.Id;
                    postFile.PostId = post.Id;
                }
            }
            catch
            {
                SetAlert("Tải lên tệp không thành công.", "error");
                PrepareDropdownList(viewModel);
                ApplyPostType(viewModel);
                return View("Edit", viewModel);
            }

            Mapper.Map(viewModel, post);
            post.DateUpdated = DateTime.Now;
            post.AuthorId = User.Identity.GetUserId();

            if (file != null && file.ContentLength > 0)
                _unitOfWork.PostFiles.Add(ref postFile);
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

        [NonAction]
        private void ApplyPostType(PostViewModel viewModel)
        {
            var data = new PostTypeData().Data;
            viewModel.PostTypeList = new SelectList(data, "Id", "Name");
        }

        private void SaveFile(string fileName, HttpPostedFileBase file)
        {
            var path = Server.MapPath("~/Content");
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            file.SaveAs(Path.Combine(path, fileName));
        }
        private void DeleteFile(string fileName)
        {
            var filePath = Path.Combine(Server.MapPath("~/Content"), fileName);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
        }
    }
}