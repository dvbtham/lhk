using System.Linq;
using System.Web.Mvc;
using LeHuuKhoa.Core.Utilities;
using LeHuuKhoa.Core.ViewModels;

namespace LeHuuKhoa.Areas.Administrations.Controllers
{
    public class AppSettingsController : BaseController
    {
        private readonly string[] _keys =
            { "SMTPHost", "SMTPPort", "FromEmailAddress",
            "FromEmailPassword", "FromName", "AdminEmail" };

        public ActionResult Index()
        {
            var appSetingsVm = _keys.Select(key => new AppSettingsViewModel
            {
                Key = key,
                Value = ConfigHelper.GetByKey(key)
            }).ToList();

            var viewModel = new AppSettingsViewModel
            {
                AppSettings = appSetingsVm
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(AppSettingsViewModel viewModel)
        {
            foreach (var item in viewModel.AppSettings)
            {
                ConfigHelper.SetValue(item.Key, item.Value);
            }

            SetAlert("Tất cả cài đặt đã được lưu", "success");
            return RedirectToAction("Index");
        }
    }
}