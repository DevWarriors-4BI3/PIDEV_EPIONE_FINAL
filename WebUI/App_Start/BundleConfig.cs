using System.Web;
using System.Web.Optimization;

namespace WebUI
{
    public class BundleConfig
    {
        // Pour plus d'informations sur le regroupement, visitez http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilisez la version de développement de Modernizr pour le développement et l'apprentissage. Puis, une fois
            // prêt pour la production, utilisez l'outil de génération (bluid) sur http://modernizr.com pour choisir uniquement les tests dont vous avez besoin.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
             "~/Content/bootstrap.css",
             "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/admin-lte/css/AdminLTE.css",
                      "~/admin-lte/css/skins/skin-blue.css"
                      ));

            bundles.Add(new StyleBundle("~/FrontTemplate/css").Include(
                        "~/FrontTemplate/css/bootstrap.css" ,
  "~/FrontTemplate/css/animate.css" ,
    "~/FrontTemplate/css/owl.carousel.min.css" ,
   "~/FrontTemplate/css/bootstrap-datepicker.css" ,
   "~/FrontTemplate/css/jquery.timepicker.css",
   "~/FrontTemplate/fonts/ionicons/css/ionicons.min.css" ,
   "~/FrontTemplate/fonts/fontawesome/css/font-awesome.min.css",
    "~/FrontTemplate/fonts/flaticon/font/flaticon.css" 
                     ));
            bundles.Add(new ScriptBundle("~/FrontTemplate/js").Include(
                "~/FrontTemplate/js/jquery-3.2.1.min.js" ,
                "~/FrontTemplate/js/popper.min.js",
                "~/FrontTemplate/js/bootstrap.min.js",
                "~/FrontTemplate/js/owl.carousel.min.js" ,
                "~/FrontTemplate/js/bootstrap-datepicker.js",
                "~/FrontTemplate/js/jquery.timepicker.min.js" ,
                "~/FrontTemplate/js/jquery.waypoints.min.js",
                "~/FrontTemplate/js/main.js"
        ));
            bundles.Add(new ScriptBundle("~/admin-lte/js").Include(
                         "~/admin-lte/js/app.js"));
            bundles.Add(new ScriptBundle("~/admin-lte/js").Include(
             "~/admin-lte/js/app.js",
             "~/admin-lte/plugins/fastclick/fastclick.js"
             ));
            bundles.Add(new ScriptBundle("~/admin-lte/js").Include(
         "~/admin-lte/js/app.js",
         "~/admin-lte/plugins/fastclick/fastclick.js",
         "~/admin-lte/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js"
         ));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                     "~/Content/bootstrap.css",
                     "~/Content/site.css",
                     "~/admin-lte/css/AdminLTE.css",
                     "~/admin-lte/css/skins/skin-blue.css",
                     "~/admin-lte/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css"
                     ));
        }
    }
}
