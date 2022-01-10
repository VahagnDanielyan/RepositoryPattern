using System;
using System.Collections.Generic;

namespace RepositoryPattern
{
    public interface IBaseRepository<TEntity, TKey>
        where TEntity : IEntity<TKey>
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetByID(TKey id);
        IEnumerable<TEntity> Find(Func<TEntity, bool> predicate);
        void Insert(TEntity obj);
        void Update(TEntity obj);
        void AddOrUpdate(TEntity obj);
        void Delete(TKey id);
        void Save();
    }
}
