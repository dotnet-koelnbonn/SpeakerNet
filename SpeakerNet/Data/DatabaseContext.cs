namespace SpeakerNet.Data
{
    public class DatabaseContext : IDatabaseContext
    {
        private SpeakerNetContext dbContext;

        public SpeakerNetContext DbContext
        {
            get
            {
                if (dbContext == null){
                    dbContext = new SpeakerNetContext();
                }
                return dbContext;
            }
        }
    }
}