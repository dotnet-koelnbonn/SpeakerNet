using System.Data.Entity.Infrastructure;

namespace SpeakerNet.Data
{
    public class SpeaketNetDatabaseInitializer
        : RecreateDatabaseIfModelChanges<SpeakerNetContext>
    {
        
    }
}