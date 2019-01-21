using System.Web;
using System.Web.Optimization;

namespace SmartHomeApi.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/externallibs")
                .Include("~/Scripts/jquery-{version}.min.js")
                .Include("~/Scripts/angular.min.js"));
        }
    }
}