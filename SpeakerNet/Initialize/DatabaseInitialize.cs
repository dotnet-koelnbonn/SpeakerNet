using System;
using System.Data.Entity.Database;
using SpeakerNet.Data;
using SpeakerNet.Infrastructure.Bootstrap;

namespace SpeakerNet.Initialize
{
    public class DatabaseInitialize : IBootstrapItem
    {
        public void Execute()
        {
            DbDatabase.DefaultConnectionFactory = new SqlCeConnectionFactory("System.Data.SqlServerCe.4.0");
            DbDatabase.SetInitializer(new SpeaketNetDatabaseInitializer());
        }
    }
}