using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using LeHuuKhoa.Core;
using LeHuuKhoa.Core.Models;
using LeHuuKhoa.Core.ViewModels;
using LeHuuKhoa.Persistence;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
                Email = user.Email,
                MyRoles = UserManager.GetRoles(user.Id).ToList()
            }).ToList();
            return View(userViewModels);
        }

        [AdminAuthorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AdminAuthorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserCreateViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);

            var user = new ApplicationUser
            {
                UserName = viewModel.Email,
                Email = viewModel.Email,
                EmailConfirmed = true,
                ImageUrl = viewModel.ImageUrl,
                Birthday = viewModel.Birthday,
                Gender = viewModel.Gender,
                Name = viewModel.Name,
                PhoneNumber = viewModel.PhoneNumber
            };
            
            var result = await UserManager.CreateAsync(user, viewModel.Password);
            if (result.Succeeded)
            {
                await UserManager.AddToRolesAsync(user.Id, "Mod");
                SetAlert("Bạn đã thêm một thành viên.", "success");
                return RedirectToAction("Index", "User");
            }

            AddErrors(result);

            return View(viewModel);
        }
        
        public ActionResult Edit(string id)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            var user = _unitOfWork.ApplicationUsers.Get(id);
            if (user == null) return NotFoundResult();
            var userVm = new UserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Birthday = user.Birthday,
                Gender = user.Gender,
                ImageUrl = user.ImageUrl,
                AllRoles = roleManager.Roles.ToList(),
                MyRoles = UserManager.GetRoles(user.Id).ToList()
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

        [HttpPost]
        [AdminAuthorize(Roles = "Admin")]
        public async Task<JsonResult> UpdateRole(string role, string userId)
        {
            try
            {
                var userRoles = await UserManager.GetRolesAsync(userId);

                if (userRoles.Contains(role))
                {
                    var res = await UserManager.RemoveFromRoleAsync(userId, role);
                    if (res.Succeeded)
                        SetAlert("Hủy quyền " + role + " thành công", "warning");
                    else
                        SetAlert("Hủy quyền " + role + " không thành công", "error");
                }
                else
                {
                    var res = await UserManager.AddToRoleAsync(userId, role);
                    if (res.Succeeded)
                        SetAlert("Cấp quyền " + role + " thành công", "success");
                    else
                        SetAlert("Cấp quyền " + role + " không thành công", "error");
                }

                return Json(new
                {
                    status = true
                });
            }
            catch
            {
                return Json(new
                {
                    status = false
                });
            }
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