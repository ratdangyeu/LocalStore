using System.Web.Optimization;

namespace LocalStore.WebApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.Microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.bundle.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/adminlte/plugins/fontawesome-free/css/all.min.css",
                      "~/adminlte/css/adminlte.min.css",
                      "~/adminlte/plugins/summernote/summernote-bs4.min.css",
                      "~/adminlte/plugins/jsgrid/jsgrid.min.css",
                      "~/adminlte/plugins/jsgrid/jsgrid-theme.min.css",
                      "~/adminlte/plugins/toastr/toastr.min.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/adminlte/js").Include(
                      "~/adminlte/js/adminlte.min.js",
                      "~/adminlte/plugins/jsgrid/jsgrid.min.js",
                      "~/adminlte/plugins/toastr/toastr.min.js",
                      "~/adminlte/plugins/summernote/summernote-bs4.min.js"));
        }
    }
}