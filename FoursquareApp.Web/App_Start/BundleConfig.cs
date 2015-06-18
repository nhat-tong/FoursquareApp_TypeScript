using System.Web;
using System.Web.Optimization;

namespace FoursquareApp.Web
{
    public class BundleConfig
    {
        // Pour plus d'informations sur Bundling, accédez à l'adresse http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Utilisez la version de développement de Modernizr pour développer et apprendre. Puis, lorsque vous êtes
            // prêt pour la production, utilisez l'outil de génération sur http://modernizr.com pour sélectionner uniquement les tests dont vous avez besoin.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

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

            // My bundles personalize
            bundles.Add(new ScriptBundle("~/bundles/myangular").Include(
                        "~/Scripts/angular.js", 
                        "~/Scripts/angular.min.js",
                        "~/Scripts/angular-route.js",
                        "~/Scripts/angular-route.min.js",
                        "~/Scripts/angular-animate.js",
                        "~/Scripts/angular-animate.min.js",
                        "~/Scripts/angular-resource.js",
                        "~/Scripts/angular-resource.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/myangular_ui").Include(
            "~/Scripts/angular-ui/ui-bootstrap-tpls.js",
            "~/Scripts/angular-ui/ui-bootstrap-tpls.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/myangular_animate").Include(
                        "~/Scripts/toaster.js",
                        "~/Scripts/toaster.min.js",
                        "~/Scripts/loading-bar.js",
                        "~/Scripts/loading-bar.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/myfoursquare_js").Include(
            "~/app/app.js",
            "~/app/controllers/ExploreController.js",
            "~/app/controllers/PlacesController.js",
            "~/app/controllers/AboutController.js",
            "~/app/controllers/ModalPhotoController.js",
            "~/app/controllers/UserProfileController.js",
            "~/app/controllers/SignInController.js",
            "~/app/controllers/LoginController.js",
            "~/app/services/PlaceExploreService.js",
            "~/app/services/PlacePhotoService.js",
            "~/app/services/PlaceDataService.js",
            "~/app/services/UserProfileService.js",
            "~/app/services/UserConnectionService.js",
            "~/app/filters/PlaceCategoryFilter.js",
            "~/app/directives/LoginDirective.js"
            ));

            bundles.Add(new StyleBundle("~/Content/mycss").Include(
                "~/Content/loading-bar.css",
                "~/Content/loading-bar.min.css",
                "~/Content/toaster.css"));

            bundles.Add(new StyleBundle("~/Content/mybootstrap").Include(
                "~/Content/bootstrap.css",
                "~/Content/bootstrap.min.css",
                "~/Content/amelia.css"));
        }
    }
}