using System;
using System.Data.Entity;
using SpeakerNet.Migrations;
using SpeakerNet.Models;

namespace SpeakerNet.Data
{
    internal class SpeaketNetDatabaseInitializer : MigrateDatabaseToLatestVersion<SpeakerNetDbContext, Configuration>
    {
    }
}