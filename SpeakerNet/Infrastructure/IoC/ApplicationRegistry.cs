using System;
using SpeakerNet.Data;
using SpeakerNet.Services;
using StructureMap.Configuration.DSL;

namespace SpeakerNet.Infrastructure.IoC
{
    public class ApplicationRegistry : Registry
    {
        public ApplicationRegistry()
        {
            For(typeof (IRepository<>)).HybridHttpOrThreadLocalScoped().Use(typeof (Repository<>));
            For<IDatabaseContext>()
                .HybridHttpOrThreadLocalScoped()
                .Use<DatabaseContext>();
            For<ICurrentWebUser>()
                .HybridHttpOrThreadLocalScoped();
        }
    }
}