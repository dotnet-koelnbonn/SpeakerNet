using System;
using System.Data.Entity;
using SpeakerNet.Migrations;

namespace SpeakerNet.Data
{
    internal class SpeaketNetDatabaseInitializer : MigrateDatabaseToLatestVersion<SpeakerNetDbContext, Configuration>
    {
    }
}