using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebAPI.DAL
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Find(Func<TEntity, bool> predicate);
        IList<TEntity> FindQuery(string query);
        IList<TEntity> FindQuery(string query, params object[] key);
        TEntity Get(params object[] key);
        void Update(TEntity obj);
        void Insert(TEntity obj);
        void Delete(Func<TEntity, bool> predicate);
    }
}
