using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Web.Mvc;
using Microsoft.Practices.ServiceLocation;
using SpeakerNet.Infrastructure.Mvc;
using StructureMap;
using StructureMap.ServiceLocatorAdapter;

namespace SpeakerNet.Infrastructure.Registration
{
    public static class RegisterStructureMap
    {
        private static readonly List<string> AssemblyStarts;

        static RegisterStructureMap()
        {
            AssemblyStarts = new List<string>();
            AssemblyStarts.Add(typeof (RegisterStructureMap).Assembly.GetName().Name.Split('.')[0]);
            AssemblyStarts.AddRange(GetAssemblyStartsFromAppSettings());
        }

        private static IEnumerable<string> GetAssemblyStartsFromAppSettings()
        {
            var starts = new string[0];
            var names = ConfigurationManager.AppSettings["IoC.IncludeAssemblies"];
            if (!string.IsNullOrWhiteSpace(names)){
                starts = names.Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries);
            }
            return starts;
        }

        public static void Execute()
        {
            var container = new Container();
            SetServiceLocator(container);

            container.Configure(c =>
                                    {
                                        c.Scan(x =>
                                                   {
                                                       x.AssembliesFromApplicationBaseDirectory(WithAssemblyFilter);
                                                       x.WithDefaultConventions();
                                                       x.LookForRegistries();
                                                   });
                                        c.SetAllProperties(x =>
                                                           x.TypeMatches(
                                                               type => container.Model.HasImplementationsFor(type)));
                                    });

            DependencyResolver.SetResolver(new StructureMapDependencyResolver(container));
        }


        private static bool WithAssemblyFilter(Assembly assemblyFilter)
        {
            var assemblyStart = assemblyFilter.GetName().Name.Split('.')[0];
            return AssemblyStarts.Contains(assemblyStart);
        }

        private static void SetServiceLocator(IContainer container)
        {
            var serviceLocator = new StructureMapServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => serviceLocator);
            container.Configure(x => x.For<IServiceLocator>().Singleton().Use(serviceLocator));
        }
    }
}