using System.Linq;
using System.Web.Mvc;
using AutoMapper;
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

            var page = new Page();

            Mapper.Map(viewModel, page);
            page.Id = SlugHelper.ToUnsignString(viewModel.Name);
            page.PinToHome = viewModel.PinToHomepe;

            _unitOfWork.Pages.Add(page);
            SetUnpin(page);
            _unitOfWork.Complete();

            SetAlert("Bạn đã thêm " + viewModel.Name + " thành công", "success");

            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            var page = _unitOfWork.Pages.Get(id);
            if (page == null) return NotFoundResult();

            var pageViewModel = new PageViewModel { PinToHomepe = page.PinToHome };
            Mapper.Map(page, pageViewModel);

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

            Mapper.Map(viewModel, page);
            page.PinToHome = viewModel.PinToHomepe;

            SetUnpin(page);
            _unitOfWork.Complete();

            SetAlert(viewModel.Name + " đã được cập nhật", "success");
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

        [NonAction]
        private void SetUnpin(Page page)
        {
            var pages = _unitOfWork.Pages.GetPages().Where(x => x.Id != page.Id);
            foreach (var item in pages)
            {
                if (page.PinToHome)
                    item.PinToHome = false;
            }
        }
    }
}