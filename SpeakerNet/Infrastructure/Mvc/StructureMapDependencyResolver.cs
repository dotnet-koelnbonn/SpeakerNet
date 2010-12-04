using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using StructureMap;

namespace SpeakerNet.Infrastructure.Mvc
{
    public class StructureMapDependencyResolver : IDependencyResolver
    {
        private readonly IContainer container;

        public StructureMapDependencyResolver(IContainer container)
        {
            this.container = container;
        }

        public object GetService(Type serviceType)
        {
            var instance = container.TryGetInstance(serviceType);
            if (instance == null){
                instance = AddConcreteServiceTypeToContainer(serviceType);
            }
            return instance;
        }

        private object AddConcreteServiceTypeToContainer(Type serviceType)
        {
            if (serviceType.IsAbstract || !serviceType.IsClass){
                return null;
            }
            container.Configure(x => x.For(serviceType).Use(serviceType));
            return container.TryGetInstance(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return container.GetAllInstances(serviceType).Cast<object>();
        }
    }
}