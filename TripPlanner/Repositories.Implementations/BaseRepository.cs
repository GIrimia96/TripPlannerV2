namespace Repositories.Implementations
{
    using Entity.Models;
    using Microsoft.EntityFrameworkCore;
    using Persistency.Implementations;
    using Repositories.Contracts;
    using System;
    using System.Linq;

    public class BaseRepository<T> : IBaseRepository<T>
        where T : BaseEntity
    {

        protected DbSet<T> dbSet;
        public BaseRepository(TripPlannerContext dbContext)
        {
            DbContext = dbContext;
            dbSet = DbContext.Set<T>();
        }

        public TripPlannerContext DbContext { get; }

        public void Add(T entity)
        {
            this.DbContext.Add(entity);
        }

        public void Delete(T entity)
        {
            DbContext.Remove(entity);
        }

        public T Get(Guid id)
        {
            return this.DbContext.Find<T>(id);
        }

        public IQueryable<T> Query()
        {
            return dbSet;
        }

        public void Save()
        {
            this.DbContext.SaveChanges();
        }
    }
}
