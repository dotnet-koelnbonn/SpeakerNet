using System;

namespace SpeakerNet.Data
{
    public class DatabaseContext : IDatabaseContext
    {
        readonly Lazy<SpeakerNetDbContext> dbContext;

        public DatabaseContext()
        {
            dbContext = new Lazy<SpeakerNetDbContext>(() => new SpeakerNetDbContext());
        }

        public SpeakerNetDbContext DbContext
        {
            get { return dbContext.Value; }
        }

        public void Dispose()
        {
            if (dbContext.IsValueCreated) {
                dbContext.Value.Dispose();
            }
        }
    }
}