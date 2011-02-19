using System;
using System.Linq;

namespace SpeakerNet.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IDatabaseContext _dbContext;

        public Repository(IDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<T> Entities
        {
            get { return _dbContext.DbContext.Set<T>(); }
        }

        public void Add(T entity)
        {
            _dbContext.DbContext.Set<T>().Add(entity);
        }

        public void Remove(T entity)
        {
            _dbContext.DbContext.Set<T>().Remove(entity);
        }

        public void SaveChanges()
        {
            _dbContext.DbContext.SaveChanges();
        }
    }
}