using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using LeHuuKhoa.Core;
using LeHuuKhoa.Core.Models;
using LeHuuKhoa.Core.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace LeHuuKhoa.Areas.Administrations.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public UserController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }


        public ApplicationSignInManager SignInManager
        {
            get => _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            private set => _signInManager = value;
        }

        public ApplicationUserManager UserManager
        {
            get => _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            private set => _userManager = value;
        }


        public ActionResult Index()
        {
            var users = _unitOfWork.ApplicationUsers.GetUsers();
            var userViewModels = users.Select(user => new UserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                Birthday = user.Birthday,
                Gender = user.Gender,
                ImageUrl = user.ImageUrl,
                Email = user.Email
            }).ToList();
            return View(userViewModels);
        }

        public ActionResult Edit(string id)
        {
            var user = _unitOfWork.ApplicationUsers.Get(id);
            if (user == null) return NotFoundResult();
            var userVm = new UserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Birthday = user.Birthday,
                Gender = user.Gender,
                ImageUrl = user.ImageUrl
            };
            return View(userVm);
        }

        [HttpPost]
        public ActionResult Update(UserViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                SetAlert("Thông tin không được lưu", "error");
                return View("Edit", viewModel);
            }
            var user = _unitOfWork.ApplicationUsers.Get(viewModel.Id);
            if (user == null) return NotFoundResult();

            user.Modify(viewModel.Name, viewModel.Email, viewModel.ImageUrl, viewModel.Birthday, viewModel.Gender);
            _unitOfWork.Complete();
            SetAlert("Thông tin đã được thay đổi", "success");
            return RedirectToAction("Index");
        }
        
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            if (!result.Succeeded)
            {
                AddErrors(result);
                return View(model);
            }

            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

            if (user != null)
                await SignInManager.SignInAsync(user, false, false);

            SetAlert("Mật khẩu đã được thay đổi", "success");
            return RedirectToAction("Edit", "User", new { id = User.Identity.GetUserId() });
        }
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}