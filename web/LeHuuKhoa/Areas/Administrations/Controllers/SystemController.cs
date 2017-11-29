using System.Linq;
using System.Web.Mvc;
using LeHuuKhoa.Areas.Administrations.Models;
using LeHuuKhoa.Core.Models;
using LeHuuKhoa.Persistence;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LeHuuKhoa.Areas.Administrations.Controllers
{
    [Authorize]
    public class SystemController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public SystemController()
        {
            _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
        }
        
        public PartialViewResult UserProfile(int zone = 10)
        {
            return PartialView(GetUserViewModel(zone));
        }

        private UserNavbarViewModel GetUserViewModel(int zone)
        {
            var userId = User.Identity.GetUserId();
            var user = _userManager.Users.SingleOrDefault(x => x.Id == userId);
            if (user == null) return new UserNavbarViewModel();
            var mzone = (zone == (int) AdminZone.Sidebar) ? AdminZone.Sidebar : AdminZone.TopNavbar;
            var userVm = new UserNavbarViewModel { Name = user.Name, Avatar = user.ImageUrl, Zone = mzone };
            return userVm;
        }
    }
}