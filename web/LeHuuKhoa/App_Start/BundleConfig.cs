using System.Web.Optimization;

namespace LeHuuKhoa
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/front/scripts").Include(
                      "~/Content/front/assets/vendor/bootstrap/js/bootstrap.min.js",
                      "~/Scripts/jquery.unobtrusive-ajax.js",
                      "~/Content/front/assets/js/jquery.lazyloadxt.min.js",
                      "~/Content/front/assets/js/scrollTop.js",
                      "~/Content/front/assets/js/main.js"));

            bundles.Add(new StyleBundle("~/front/styles").Include(
                      "~/Content/front/assets/vendor/bootstrap/css/bootstrap.min.css",
                      "~/Content/front/assets/css/jquery.lazyloadxt.spinner.css")
                .Include("~/Content/front/assets/vendor/font-awesome/css/font-awesome.min.css", new CssRewriteUrlTransform()));
            
            BundleTable.EnableOptimizations = true;
        }
    }
}
