using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;

namespace SpeakerNet.Data
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        readonly IDatabaseContext context;

        public Repository(IDatabaseContext context)
        {
            this.context = context;
        }

        public IQueryable<T> Entities
        {
            get { return context.DbContext.Set<T>(); }
        }

        public IQueryable<T> Include(params string[] paths)
        {
            var query = context.DbContext.Set<T>().Include(paths.First());
            foreach (var path in paths.Skip(1)) {
                query = query.Include(path);
            }
            return query;
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
            try {
                context.DbContext.SaveChanges();
            }
            catch (DbEntityValidationException exception) {
                var sb = new StringBuilder();
                foreach (var validationResult in exception.EntityValidationErrors) {
                    sb.AppendLine(validationResult.Entry.Entity.GetType().Name);
                    foreach (var validationError in validationResult.ValidationErrors) {
                        sb.AppendFormat("  {0}: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        sb.AppendLine();
                    }
                }
                if (sb.Length>0) {
                    throw new ValidationException(sb.ToString());
                }
            }
        }
    }
}