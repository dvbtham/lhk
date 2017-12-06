using System.Collections.Generic;

namespace LeHuuKhoa.Core.ViewModels
{
    public class AppSettingsViewModel
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public IList<AppSettingsViewModel> AppSettings { get; set; } = new List<AppSettingsViewModel>();
    }
   
}