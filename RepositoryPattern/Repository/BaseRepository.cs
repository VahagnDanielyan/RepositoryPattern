using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RepositoryPattern
{
    public class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        public Lazy<List<TEntity>> Data { get; set; }

        private readonly string _fileName;
        public BaseRepository(string fileName)
        {
            _fileName = fileName;
            Data = new Lazy<List<TEntity>>(() =>
            {
                return XmlExtensions.LoadFromXml<TEntity>(fileName) as List<TEntity>;
            });
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Data.Value;
        }

        public TEntity GetByID(TKey id)
        {
            List<TEntity> items = Data.Value;
            return items.FirstOrDefault(f => f.Id.Equals(id));
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Insert(TEntity obj)
        {
            List<TEntity> items = Data.Value;
            items.Add(obj);
            Save();
        }

        public void Update(TEntity obj)
        {
            List<TEntity> items = Data.Value;
            TEntity imodel = obj;
            items.Remove(items.FirstOrDefault(f => f.Id.Equals(imodel.Id)));
            items.Add(imodel);
            Save();
        }

        public void Delete(TKey id)
        {
            List<TEntity> items = Data.Value;
            items.Remove(items.First(f => f.Id.Equals(id)));
            Save();
        }
        public void Save()
        {
            XmlExtensions.WriteToXml(Data.Value, _fileName);
        }
    }
}
