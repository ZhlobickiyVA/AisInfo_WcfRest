using System.Web;
using System.Web.Optimization;

namespace AisInformMVC
{
  public class BundleConfig
  {
    // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
    public static void RegisterBundles(BundleCollection bundles)
    {
      bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                  "~/Scripts/jquery-{version}.js" ));
      

        bundles.Add(new ScriptBundle("~/bundles/Scripts").Include(
                  "~/Scripts/Scripts.js"));

      bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                  "~/Scripts/jquery.validate*"));

      bundles.Add(new ScriptBundle("~/bundles/slimscroll").Include(
                  "~/Scripts/jquery-slimscroll/jquery.slimscroll.js"));

      bundles.Add(new ScriptBundle("~/bundles/Theme").Include(
                  "~/Scripts/klorofil-common.js"));

      //"~/bundles/ckedit"

      bundles.Add(new ScriptBundle("~/bundles/ckedit").Include(
                  "~/Control/ckeditor/ckeditor.js"));


      // Используйте версию Modernizr для разработчиков, чтобы учиться работать. Когда вы будете готовы перейти к работе,
      // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.

      bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                  "~/Scripts/modernizr-*"));

      bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/respond.js"
                , "~/Scripts/html5shiv.min.js"));

      bundles.Add(new StyleBundle("~/Content/css")
        .Include("~/Content/bootstrap.css")
        .Include("~/Content/Style.css")
        .Include("~/Content/main.css")
        .Include("~/Content/ie10-viewport-bug-workaround.css")
        .Include("~/Content/googleforn.css")
        .Include( "~/Content/linearicons/style.css")
        .Include("~/Content/font-awesome/css/font-awesome.min.css")
        .Include("~/Content/ErrorStyle.css"));
    }
  }
}
