using System.Web.Optimization;
using WebHelpers.Mvc5;

namespace Veronica.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Bundles/css")
                .Include("~/Content/css/bootstrap.min.css", new CssRewriteUrlTransformAbsolute())
                .Include("~/Content/css/bootstrap-select.css")
                .Include("~/Content/css/bootstrap-datepicker3.min.css")
                .Include("~/Content/css/font-awesome.min.css", new CssRewriteUrlTransformAbsolute())
                .Include("~/Content/css/icheck/blue.min.css", new CssRewriteUrlTransformAbsolute())
                .Include("~/Content/css/AdminLTE.css", new CssRewriteUrlTransformAbsolute())
                .Include("~/Content/css/skins/skin-blue.css"));

            bundles.Add(new ScriptBundle("~/Bundles/js")
                .Include("~/Content/js/plugins/jquery/jquery-2.2.4.js")
                .Include("~/Content/js/plugins/bootstrap/bootstrap.js")
                .Include("~/Content/js/plugins/fastclick/fastclick.js")
                .Include("~/Content/js/plugins/slimscroll/jquery.slimscroll.js")
                .Include("~/Content/js/plugins/bootstrap-select/bootstrap-select.js")
                .Include("~/Content/js/plugins/moment/moment.js")
                .Include("~/Content/js/plugins/datepicker/bootstrap-datepicker.js")
                .Include("~/Content/js/plugins/icheck/icheck.js")
                .Include("~/Content/js/plugins/validator.js")
                .Include("~/Content/js/plugins/inputmask/jquery.inputmask.bundle.js")
                .Include("~/Content/js/adminlte.js")
                .Include("~/Content/js/init.js"));

            bundles.Add(new ScriptBundle("~/bundles/Dollar").Include(
                         "~/Scripts/Dollar.js"));

            bundles.Add(new ScriptBundle("~/bundles/Errordashboard").Include(
                         "~/Scripts/Errordashboard.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryBlockUI").Include(
                        "~/Scripts/jquery.blockUI.js"));

            bundles.Add(new ScriptBundle("~/bundles/dataTable").Include(
                        "~/Scripts/DataTables/jquery.DataTables.js",
                        "~/Scripts/DataTables/dataTables.bootstrap.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap-dialog.min.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/application").Include(
                        "~/Scripts/app.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/dashboard").Include(
                        "~/Scripts/dashboard.js"
                        ));

            bundles.Add(new StyleBundle("~/content/css").Include(
                      "~/content/bootstrap/bootstrap.css",
                      "~/content/bootstrap/bootstrap-theme.css",
                      "~/content/bootstrap/bootstrap-dialog.min.css",
                       "~/content/bootstrap/dataTables.bootstrap.min.css",
                    "~/content/site.css"));

//#if DEBUG
//            BundleTable.EnableOptimizations = false;
//#else
//            BundleTable.EnableOptimizations = true;
//#endif
        }
    }
}
