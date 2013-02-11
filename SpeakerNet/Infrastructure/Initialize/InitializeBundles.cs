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
                    "~/Scripts/angular-resource.js",
                    "~/Scripts/angular-sanitize.js",
                    "~/Scripts/i18n/angular-locale_de-de.js",
                    "~/Scripts/i18n/angular-locale_de.js",
                    "~/Scripts/jquery.signalR-1.*"
                );
            bundles.Add(scripts);
            scripts = new ScriptBundle("~/resources/sessionvoting")
                .Include(
                    "~/js/Transformations.js",
                    "~/js/VotingController.js",
                    "~/js/ResultController.js",
                    "~/js/SessionVotingServices.js",
                    "~/js/SessionVoting.js"
                );
            bundles.Add(scripts);
        }
    }
}