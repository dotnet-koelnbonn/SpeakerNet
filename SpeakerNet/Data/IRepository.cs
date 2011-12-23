using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeakerNet.Data
{
    public interface IRepository<T> where T : class 
    {
       IQueryable<T> Entities { get; }
        void Add(T entity);
        void Remove(T entity);
        void SaveChanges();
        IQueryable<T> Include(params string[] paths);
    }
}