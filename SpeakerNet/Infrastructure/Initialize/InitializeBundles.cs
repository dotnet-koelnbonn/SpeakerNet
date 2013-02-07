using System.Web.Optimization;
using Aperea.Infrastructure.Bootstrap;

namespace SpeakerNet.Infrastructure.Initialize
{
    public class InitializeBundles : BootstrapItem
    {
        public override void Execute()
        {
            CreateScriptsBundles(BundleTable.Bundles);
            CreateStyleBundles(BundleTable.Bundles);
        }

        static void CreateStyleBundles(BundleCollection bundles)
        {
            var styles = new StyleBundle("~/resources/styles")
                .Include("~/Content/Site.css");
            bundles.Add(styles);
        }

        static void CreateScriptsBundles(BundleCollection bundles)
        {
            var scripts = new ScriptBundle("~/resources/scripts")
                .Include(
                    "~/Scripts/jquery-{version}.js",
                    "~/Scripts/jquery.validate.js",
                    "~/Scripts/jquery.validate.unobstrusive.js"
                );
            bundles.Add(scripts);

            scripts = new ScriptBundle("~/resources/angular")
                .Include(
                    "~/Scripts/angular.js",
                    "~/Scripts/i18n/angular-locale_de-de.js",
                    "~/Scripts/i18n/angular-locale_de.js"
                );
            bundles.Add(scripts);
        }
    }
}