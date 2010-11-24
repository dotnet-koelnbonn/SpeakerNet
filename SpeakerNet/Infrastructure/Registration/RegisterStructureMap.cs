using System.Reflection;
using System.Web.Mvc;
using Microsoft.Practices.ServiceLocation;
using StructureMap;
using StructureMap.ServiceLocatorAdapter;

namespace SpeakerNet.Infrastructure.Registration
{
    public static class RegisterStructureMap
    {
        private static readonly string AssemblyStart;

        static RegisterStructureMap()
        {
            AssemblyStart = typeof (RegisterStructureMap).Assembly.GetName().Name.Split('.')[0];
        }

        public static void Execute()
        {
            var container = new Container();

            container.Configure(c =>
                                    {
                                        c.Scan(x =>
                                                   {
                                                       x.AssembliesFromApplicationBaseDirectory(OnAssemblyFilter);
                                                       x.WithDefaultConventions();
                                                       x.LookForRegistries();
                                                   });
                                        c.SetAllProperties(x =>
                                                           x.TypeMatches(
                                                               type => container.Model.HasImplementationsFor(type)));
                                    });

            SetServiceLocator(container);
            DependencyResolver.SetResolver(new StructureMapDependencyResolver(container));
            FilterProviders.Providers.Add(new StructureMapFilterAttributeFilterProvider(container));
        }


        private static bool OnAssemblyFilter(Assembly assemblyFilter)
        {
            return assemblyFilter.GetName().Name.StartsWith(AssemblyStart);
        }

        private static void SetServiceLocator(IContainer container)
        {
            var serviceLocator = new StructureMapServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => serviceLocator);
        }
    }
}