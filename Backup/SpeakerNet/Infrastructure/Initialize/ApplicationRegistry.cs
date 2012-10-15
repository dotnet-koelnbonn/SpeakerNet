using System;
using SpeakerNet.Data;
using StructureMap;
using StructureMap.Configuration.DSL;
using StructureMap.Pipeline;

namespace SpeakerNet.Infrastructure.Initialize
{
    public class ApplicationRegistry : Registry
    {
        public ApplicationRegistry()
        {
            Scan(x=> 
            {
                x.AssembliesFromApplicationBaseDirectory();
                x.AddAllTypesOf(typeof (IRepository<>));
            });

            For<IDatabaseContext>()
                .LifecycleIs(Lifecycles.GetLifecycle(InstanceScope.Hybrid))
                .Use<DatabaseContext>();
        }
    }
}