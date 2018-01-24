using System.Web.Optimization;

namespace Ks.MVC
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/scripts/base")
                .Include($"~/Content/scripts/jquery/jquery.min.js")
                //.Include("~/Content/scripts/bootstrap/js/bootstrap.min.js")
                .Include("~/Content/scripts/layui/layui.js")
                .Include("~/Content/scripts/ui.js"));

            bundles.Add(new StyleBundle("~/styles/base")
                .Include("~/Content/scripts/layui/css/layui.css")
                .Include("~/Content/scripts/bootstrap/css/bootstrap.min.css")
                .Include("~/Content/styles/theme.css")
                .Include("~/Content/styles/font-awesome.min.css"));
        }
    }
}