using System.Web.Mvc;
using static System.String;

namespace LeHuuKhoa.Core.Utilities
{
    public static class HtmlHelperExtensions
    {
        public static string IsSelected(this HtmlHelper html, string controller = null, string action = null)
        {
            var cssClass = "";
            var currentAction = (string)html.ViewContext.RouteData.Values["action"];
            var currentController = (string)html.ViewContext.RouteData.Values["controller"];

            if (currentController == controller && currentAction == action)
            {
                cssClass = "active";
            }

            return cssClass;
        }
    }
}