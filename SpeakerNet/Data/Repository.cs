using System;
using System.Linq;

namespace SpeakerNet.Data
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        private readonly IDatabaseContext context;

        public Repository(IDatabaseContext context)
        {
            this.context = context;
        }

        public IQueryable<T> Entities
        {
            get { return context.DbContext.Set<T>(); }
        }

        public void Add(T entity)
        {
            context.DbContext.Set<T>().Add(entity);
        }

        public void Remove(T entity)
        {
            context.DbContext.Set<T>().Remove(entity);
        }

        public void SaveChanges()
        {
            context.DbContext.SaveChanges();
        }
    }
}