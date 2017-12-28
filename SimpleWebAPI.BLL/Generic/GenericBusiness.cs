using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleWebAPI.DAL;


namespace SimpleWebAPI.BLL.Generic
{
    public class GenericBusiness<TEntity> where TEntity : class
    {
        private IRepository<TEntity> _repositoryGeneric;

        public GenericBusiness()
        {
            _repositoryGeneric = new Repository<TEntity>();
        }

        public void Insert(TEntity obj)
        {
            _repositoryGeneric.Insert(obj);
        }

        public void Delete(Func<TEntity, bool> predicate)
        {
            _repositoryGeneric.Delete(predicate);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _repositoryGeneric.GetAll();
        }

        public IList<TEntity> FindQuery(string query)
        {
            return _repositoryGeneric.FindQuery(query);
        }

        public IList<TEntity> FindQuery(string query, params object[] key)
        {
            return _repositoryGeneric.FindQuery(query, key);
        }

        public IQueryable<TEntity> Find(Func<TEntity, bool> predicate)
        {
            return _repositoryGeneric.Find(predicate);
        }

        public TEntity Get(params object[] key)
        {
            return _repositoryGeneric.Get(key);
        }

        public void Update(TEntity obj)
        {
            _repositoryGeneric.Update(obj);
        }
    }
}
