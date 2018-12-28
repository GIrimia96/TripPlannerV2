using Entity.Models;
using System;
using System.Linq;

namespace Repositories.Contracts
{
    public interface IBaseRepository<T>
        where T : BaseEntity
    {
        IQueryable<T> Query();

        T Get(Guid id);

        void Add(T entity);

        void Save();

        void Delete(T entity);
    }
}
