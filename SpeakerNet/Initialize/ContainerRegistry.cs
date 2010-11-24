using SpeakerNet.Infrastructure.Bootstrap;
using SpeakerNet.ModelBinder;
using StructureMap.Configuration.DSL;

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
                x.AddAllTypesOf<IBootstrapItem>();
            });
        }
    }
}