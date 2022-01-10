using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RepositoryPattern
{
    public class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        private Lazy<Dictionary<TKey, TEntity>> _dataFactory;

        private readonly string _fileName;
        public BaseRepository(string fileName)
        {
            _fileName = fileName;
            _dataFactory = new Lazy<Dictionary<TKey, TEntity>>(() =>
            {
                return XmlExtensions
                    .LoadFromXml<TEntity>(fileName)
                    .ToDictionary(p => p.Id);
            });
        }

        private Dictionary<TKey, TEntity> _data => _dataFactory.Value;

        public IEnumerable<TEntity> GetAll() => _data.Values;

        public TEntity GetByID(TKey id)
        {
            if (_data.TryGetValue(id, out TEntity entity))
                return entity;

            throw new Exception("");
        }

        public IEnumerable<TEntity> Find(Func<TEntity, bool> predicate) =>
            GetAll().Where(predicate);

        public void Insert(TEntity obj)
        {
            if (_data.ContainsKey(obj.Id))
                throw new Exception("");

            _data.Add(obj.Id, obj);
        }

        public void AddOrUpdate(TEntity obj)
        {
            _data[obj.Id] = obj;
        }

        public void Update(TEntity obj)
        {
            if (_data.ContainsKey(obj.Id))
                _data[obj.Id] = obj;
        }

        public void Delete(TKey id)
        {
            _data.Remove(id);
        }
        public void Save()
        {
            XmlExtensions.WriteToXml(_data.Values.ToList(), _fileName);
        }
    }
}
