using System;
using System.Web.Mvc;
using System.Web.Routing;
using Aperea.Infrastructure.Bootstrap;
using SpeakerNet.Controllers;

namespace SpeakerNet.Infrastructure.Initialize
{
    public class InitializeMvcRoutes : BootstrapItem
    {
        public override void Execute()
        {
            RegisterRoutes(RouteTable.Routes);
        }

        static string NameOf<T>() where T : Controller
        {
            var name = typeof (T).Name;
            return name.Substring(0, name.LastIndexOf("Controller", System.StringComparison.Ordinal));
        }

        static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("images/{*pathInfo}");

            routes.MapRoute(
                name: "FederationMedatadata",
                url: "federationmetadata/2007-06/federationmetadata.xml",
                defaults: new {controller = NameOf<MetadataController>(), action = "Federation"}
                );

            routes.MapRoute(
                name: "SpeakerSession",
                url: "speakersession/{action}/{speakerid}/{id}",
                defaults: new {
                    controller = NameOf<SpeakerSessionController>(),
                    action = "List",
                    id = UrlParameter.Optional
                }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new {
                    controller = NameOf<HomeController>(),
                    action = "Index",
                    id = UrlParameter.Optional
                }
                );
        }
    }
}