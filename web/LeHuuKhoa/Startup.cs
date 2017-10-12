using System.Web.Mvc;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LeHuuKhoa.Startup))]
namespace LeHuuKhoa
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }
    }
}
