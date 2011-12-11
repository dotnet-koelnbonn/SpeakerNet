using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using SpeakerNet.Data;
using SpeakerNet.Infrastructure.Bootstrap;

namespace SpeakerNet.Initialize
{
    public class DatabaseInitialize : IBootstrapItem
    {
        public void Execute()
        {
            Database.DefaultConnectionFactory = new SqlCeConnectionFactory("System.Data.SqlServerCe.4.0");
            Database.SetInitializer(new SpeaketNetDatabaseInitializer());
        }
    }
}