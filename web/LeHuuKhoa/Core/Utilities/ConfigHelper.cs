using System.Configuration;
using System.Web.Configuration;

namespace LeHuuKhoa.Core.Utilities
{
    public class ConfigHelper
    {
        public static string GetByKey(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
        public static void SetValue(string key, string value)
        {
            var objConfig = WebConfigurationManager.OpenWebConfiguration("~");
            var objAppsettings = (AppSettingsSection)objConfig.GetSection("appSettings");

            if (objAppsettings == null || key == null) return;

            objAppsettings.Settings[key].Value = value;
            objConfig.Save();
        }
    }
}