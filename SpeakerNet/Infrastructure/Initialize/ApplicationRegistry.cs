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
            For(typeof (IRepository<>)).HybridHttpOrThreadLocalScoped().Use(typeof (Repository<>));
            For<IDatabaseContext>()
                .HybridHttpOrThreadLocalScoped()
                .Use<DatabaseContext>();
        }
    }
}