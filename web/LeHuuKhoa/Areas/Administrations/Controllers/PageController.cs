using System.Web.Helpers;
using System.Web.Mvc;
using LeHuuKhoa.Core;
using LeHuuKhoa.Core.Models;
using LeHuuKhoa.Core.Utilities;
using LeHuuKhoa.Core.ViewModels;

namespace LeHuuKhoa.Areas.Administrations.Controllers
{
    public class PageController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;

        public PageController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ActionResult Index()
        {
            var pages = _unitOfWork.Pages.GetPages();
            return View(pages);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PageViewModel viewModel)
        {
            if (!ModelState.IsValid) return View("Create", viewModel);

            var page = new Page
            {
                Id = SlugHelper.ToUnsignString(viewModel.Name),
                Name = viewModel.Name,
                BackgroundImage = viewModel.BackgroundImage,
                Content = viewModel.Content
            };

            _unitOfWork.Pages.Add(page);
            _unitOfWork.Complete();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            var page = _unitOfWork.Pages.Get(id);
            if (page == null) return NotFoundResult();

            var pageViewModel = new PageViewModel
            {
                Id = page.Id,
                Name = page.Name,
                BackgroundImage = page.BackgroundImage,
                Content = page.Content
            };
            return View(pageViewModel);
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Update(PageViewModel viewModel)
        {
            if (!ModelState.IsValid) return View("Edit", viewModel);

            var page = _unitOfWork.Pages.Get(viewModel.Id);

            if (page == null) return NotFoundResult();

            page.Modify(viewModel.Id, viewModel.Name, viewModel.BackgroundImage , viewModel.Content);
            _unitOfWork.Complete();

            return RedirectToAction("Index");
        }

        public JsonResult Delete(string id)
        {
            var page = _unitOfWork.Pages.Get(id);
            if (page == null) return Json("Không tìm thấy dữ liệu");

            _unitOfWork.Pages.Delete(page);
            _unitOfWork.Complete();

            return Json(page);
        }
    }
}