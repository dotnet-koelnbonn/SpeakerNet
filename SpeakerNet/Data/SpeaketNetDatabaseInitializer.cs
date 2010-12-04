using System.Data.Entity.Infrastructure;
using SpeakerNet.Models;

namespace SpeakerNet.Data
{
    public class SpeaketNetDatabaseInitializer
        : RecreateDatabaseIfModelChanges<SpeakerNetDbContext>
    {
        protected override void Seed(SpeakerNetDbContext context)
        {
            base.Seed(context);
            context.Events.Add(Event.Create("dotnet Cologne 2011"));
            context.Speakers.Add(Speaker.Create("Herr","Albert","Weinert","info@der-albert.com"));
            context.SaveChanges();
        }
    }
}