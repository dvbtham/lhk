using System.Configuration;

namespace LeHuuKhoa.Core.Utilities
{
    public class ConfigHelper
    {
        public static string GetByKey(string key)
        {
            return ConfigurationManager.AppSettings[key].ToString();
        }
    }
}