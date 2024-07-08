using System.Web;
using System.Web.Optimization;

namespace CL.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/modernizr-*",
                "~/Scripts/bootstrap.js",
                "~/Scripts/typeahead.bundle.js",
                "~/Scripts/toastr.js"
           ));

            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"
            //            ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js"
            //        ));



            bundles.Add(new ScriptBundle("~/bundles/cl-authenticated").Include(
                      "~/Scripts/cl/mainAuthenticated.js",
                      "~/Scripts/cl/typeAhead.js"
                    ));

            bundles.Add(new ScriptBundle("~/bundles/cl").Include(
                 "~/Scripts/cl/main.js"
               ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/styles/main-page.css",
                      "~/Content/styles/type-ahead.css",
                      "~/Content/toastr.css"));


            bundles.Add(new StyleBundle("~/Content/postBodyCss").Include(
                    "~/Content/toastr.css"));
        }
    }
}
