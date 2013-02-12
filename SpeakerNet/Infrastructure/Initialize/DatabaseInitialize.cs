using System;
using System.Data.Entity;
using Aperea.Data;
using Aperea.Infrastructure.Bootstrap;
using SpeakerNet.Data;

namespace SpeakerNet.Infrastructure.Initialize
{
    public class DatabaseInitialize : BootstrapItem
    {
        public override void Execute()
        {
            DbContextFactory.SetDbContextType<SpeakerNetDbContext>();
            Database.SetInitializer(new SpeaketNetDatabaseInitializer());
        }
    }
}