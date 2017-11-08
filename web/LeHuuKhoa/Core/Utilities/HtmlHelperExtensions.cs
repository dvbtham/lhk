using System.Web.Mvc;
using static System.String;

namespace LeHuuKhoa.Core.Utilities
{
    public static class HtmlHelperExtensions
    {
        public static string IsSelected(this HtmlHelper html, string controller = null, string action = null)
        {
            const string cssClass = "active";
            var currentAction = (string)html.ViewContext.RouteData.Values["action"];
            var currentController = (string)html.ViewContext.RouteData.Values["controller"];

            if (IsNullOrEmpty(controller))
                controller = currentController;

            if (IsNullOrEmpty(action))
                action = currentAction;

            return controller == currentController && action == currentAction ?
                cssClass : Empty;
        }
    }
}