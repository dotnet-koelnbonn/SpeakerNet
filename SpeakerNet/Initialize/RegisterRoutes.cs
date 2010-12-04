using System.Web.Mvc;
using System.Web.Routing;
using SpeakerNet.Infrastructure.Bootstrap;

namespace SpeakerNet.Initialize
{
    public class RegisterRoutes : IBootstrapItem
    {
        public void Execute()
        {
            AreaRegistration.RegisterAllAreas();
            Register(RouteTable.Routes);
            RegisterGlobalFilters(GlobalFilters.Filters);
        }

        private void Register(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "SpeakerSession", // Route name
                "SpeakerSession/{action}/{speakerid}/{id}", // URL with parameters
                new {
                    controller = "SpeakerSession",
                    action = "List",
                    id = UrlParameter.Optional
                } // Parameter defaults
                );

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new {
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional
                } // Parameter defaults
                );
        }

        public void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}