using System;
using System.Data.Entity.Migrations;

namespace SpeakerNet.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Data.SpeakerNetDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(Data.SpeakerNetDbContext context)
        {
        }
    }
}