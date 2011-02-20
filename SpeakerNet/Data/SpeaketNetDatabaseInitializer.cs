using System;
using System.Data.Entity.Database;
using SpeakerNet.Models;

namespace SpeakerNet.Data
{
    public class SpeaketNetDatabaseInitializer : CreateDatabaseIfNotExistsWithoutModelCheck<SpeakerNetDbContext>
    {
        protected override void Seed(SpeakerNetDbContext context)
        {
            base.Seed(context);
            context.Events.Add(Event.Create("dotnet Cologne 2011"));
            context.Speakers.Add(Speaker.Create("Herr", "Albert", "Weinert", "info@der-albert.com"));
        }
    }
}