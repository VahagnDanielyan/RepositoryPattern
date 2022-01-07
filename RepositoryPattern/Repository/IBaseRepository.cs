using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RepositoryPattern
{
    public interface IBaseRepository<TEntity, TKey>
        where TEntity : IEntity<TKey>
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetByID(TKey id);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        void Insert(TEntity obj);
        void Update(TEntity obj);
        void Delete(TKey id);
        void Save();
    }
}
