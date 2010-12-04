using System;

namespace SpeakerNet.Data
{
    public class EntityFrameworkDatabaseContext : IDatabaseContext
    {
        private SpeakerNetDbContext dbContext;

        public SpeakerNetDbContext DbContext
        {
            get
            {
                if (dbContext == null){
                    dbContext = new SpeakerNetDbContext();
                }
                return dbContext;
            }
        }


        public void Dispose()
        {
            if (dbContext!=null){
                dbContext.Dispose();
                dbContext = null;
            }
        }
    }
}