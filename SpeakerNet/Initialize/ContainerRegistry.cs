using SpeakerNet.Data;
using SpeakerNet.Infrastructure.Bootstrap;
using SpeakerNet.ModelBinder;
using StructureMap;
using StructureMap.Configuration.DSL;
using StructureMap.Pipeline;

namespace SpeakerNet.Initialize
{
    public class ContainerRegistry : Registry
    {
        public ContainerRegistry()
        {
            Scan(x=> 
            {
                x.AssembliesFromApplicationBaseDirectory();
                x.ConnectImplementationsToTypesClosing(typeof (IModelBinder<>));
                x.AddAllTypesOf(typeof (IRepository<>));
                x.AddAllTypesOf<IBootstrapItem>();
            });

            For<IDatabaseContext>()
                .LifecycleIs(Lifecycles.GetLifecycle(InstanceScope.Hybrid))
                .Use<EntityFrameworkDatabaseContext>();
        }
    }
}