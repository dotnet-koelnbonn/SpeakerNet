using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.ServiceLocation;
using StructureMap;

namespace SpeakerNet.Infrastructure.Registration
{
    internal class StructureMapServiceLocator : ServiceLocatorImplBase
    {
        private readonly IContainer container;

        public StructureMapServiceLocator(IContainer container)
        {
            this.container = container;
        }

        protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            return container.GetAllInstances(serviceType).Cast<object>();
        }

        protected override object DoGetInstance(Type serviceType, string key)
        {
            return container.GetInstance(serviceType, key);
        }
    }
}