using System.Linq;

namespace SpeakerNet.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IDatabaseContext dbContext;

        public Repository(IDatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<T> Entities
        {
            get { return dbContext.DbContext.Set<T>(); }
        }

        public void Add(T entity)
        {
            dbContext.DbContext.Set<T>().Add(entity);
        }

        public void SaveChanges()
        {
            dbContext.DbContext.SaveChanges();
        }
    }
}