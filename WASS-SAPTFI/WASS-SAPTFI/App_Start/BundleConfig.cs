using System.Web;
using System.Web.Optimization;

namespace WASS_SAPTFI
{
    public class BundleConfig
    {
        // Para obtener más información acerca de Bundling, consulte http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/wasscript").Include(
               "~/Scripts/jquery-{version}.js",
               "~/Scripts/jquery-ui-{version}.js",
               "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"
                      

               ));

           
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información sobre los formularios. De este modo, estará
            // preparado para la producción y podrá utilizar la herramienta de creación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            //bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/css/bootstrap.css",
                                                                    "~/Content/css/bootstrap.min.css",
                                                                    "~/Content/css/simple-sidebar.css",
                                                                    "~/Content/css/font-awesome.min.css",
                                                                    "~/Content/css/font-awesome.css",
                                                                     "~/Content/css/smart_wizard.css",       // WIZARD
                                                                    "~/Content/css/smart_wizard_vertical.css" //WIZARD
                                                                    ));
                                                                               
            bundles.Add(new ScriptBundle("~/Content/js").Include(  "~/Content/js/bootstrap.js",
                                                                    "~/Content/js/bootstrap.min.js",
                                                                    "~/Content/js/sidebar_menu.js",
                                                                    "~/Content/js/jquery-1.11.2.min.js",
                                                                    "~/Content/js/jquery.js"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));
        }
    }
}