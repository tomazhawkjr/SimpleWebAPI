using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleWebAPI.DAL.Context;


namespace SimpleWebAPI.DAL
{
    public class Repository<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class
    {
        private BDContext ctx;

        public Repository()
        {
            ctx = new BDContext();
        }

        public IQueryable<TEntity> GetAll()
        {
            return ctx.Set<TEntity>();
        }

        public IQueryable<TEntity> Find(Func<TEntity, bool> predicate)
        {
            return GetAll().Where(predicate).AsQueryable();
        }

        public IList<TEntity> FindQuery(string query)
        {
            return ctx.Set<TEntity>().SqlQuery(query).ToList();
        }
        /// <summary>
        /// Find with Params
        /// </summary>
        /// <param name="query">Sql Query, format: SELECT * FROM myTable WHERE name = @myName</param>
        /// <param name="key">Params to Query, pass in query using @param</param>
        /// <returns></returns>
        public IList<TEntity> FindQuery(string query, params object[] key)
        {
            return ctx.Set<TEntity>().SqlQuery(query, key).ToList();
        }

        public TEntity Get(params object[] key)
        {
            return ctx.Set<TEntity>().Find(key);
        }

        public void Update(TEntity obj)
        {
            ctx.Entry(obj).State = EntityState.Modified;

            ctx.SaveChanges();
        }

        public void Insert(TEntity obj)
        {
            ctx.Set<TEntity>().Add(obj);

            ctx.SaveChanges();
        }

        public void Delete(Func<TEntity, bool> predicate)
        {
            ctx.Set<TEntity>()
                .Where(predicate).ToList()
                .ForEach(del => ctx.Set<TEntity>().Remove(del));

            ctx.SaveChanges();
        }

        public void Dispose()
        {
            ctx.Dispose();
        }

    }
}
