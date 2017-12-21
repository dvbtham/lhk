using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using LeHuuKhoa.Core;
using LeHuuKhoa.Core.Models;
using LeHuuKhoa.Core.MvcCustom;
using LeHuuKhoa.Core.Utilities;
using LeHuuKhoa.Core.ViewModels;

namespace LeHuuKhoa.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ActionResult Index()
        {
            var categories = _unitOfWork.Categories.GetCategories().OrderBy(x => x.DisplayOrder);
            return View(categories);
        }

        //[PartialCache("Cache15Min")]
        public PartialViewResult StartPageHeader()
        {
            var startPageImage = ConfigHelper.GetByKey("StartPageImage");
            ViewBag.StartPageImage = startPageImage;
            var page = _unitOfWork.Pages.GetForHomePage();
            var viewModel = Mapper.Map<Page, PageViewModel>(page);
            return PartialView("_StartPageHeader", viewModel);
        }
        
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(FeedbackViewModel model)
        {
            if(!ModelState.IsValid) return View(model);
            var feedback = new Feedback
            {
                Fullname = model.Fullname,
                Email = model.Email,
                Address = model.Address,
                Message = model.Message,
                Country = model.Country,
                Phone = model.Phone,
                Website = model.Website
            };
            
            try
            {
                _unitOfWork.Feedbacks.Add(feedback);
                _unitOfWork.Complete();

                var adminEmail = ConfigHelper.GetByKey("AdminEmail");
                var content = System.IO.File.ReadAllText(Server.MapPath("/Views/Shared/contact.html"));

                content = content.Replace("{{from}}", feedback.Fullname);
                content = content.Replace("{{email}}", feedback.Email);
                content = content.Replace("{{phone}}", feedback.Phone);
                content = content.Replace("{{website}}", feedback.Website);
                content = content.Replace("{{address}}", feedback.Address);
                content = content.Replace("{{country}}", feedback.Country);
                content = content.Replace("{{message}}", feedback.Message);

                MailHelper.SendMail(adminEmail, "Phản hồi từ Blog", content);
            }
            catch
            {
                return View(model);
            }

            ViewBag.Result = "Bạn đã gửi thông tin liên hệ thành công";
            return View(new FeedbackViewModel());
        }

        [PartialCache("Cache15Min")]
        public ActionResult RenderMenu()
        {
            var menus = _unitOfWork.Menus.GetMenus();
            var viewModel = Mapper.Map<IEnumerable<Menu>, IEnumerable<MenuViewModel>>(menus);
            return PartialView("_Menu", viewModel);
        }
    }
}