using System.Web;
using System.Web.Mvc;

namespace LeHuuKhoa.Core
{
    public class ServiceFactory
    {
        public static THelper Get<THelper>()
        {
            if (HttpContext.Current == null) return DependencyResolver.Current.GetService<THelper>();

            var key = string.Concat("factory-", typeof(THelper).Name);

            if (HttpContext.Current.Items.Contains(key)) return (THelper) HttpContext.Current.Items[key];

            var resolvedService = DependencyResolver.Current.GetService<THelper>();

            HttpContext.Current.Items.Add(key, resolvedService);

            return (THelper)HttpContext.Current.Items[key];
        }
    }
}