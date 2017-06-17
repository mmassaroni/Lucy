using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;

namespace EFRepository
{
    public class Repository : IRepository, IDisposable
    {
        protected DbContext Context;

        public Repository(DbContext context, 
            bool autoDetectChangesEnabled = false, 
            bool proxyCreationEnabled = false)
        {
            this.Context = context;
            this.Context.Configuration.AutoDetectChangesEnabled = autoDetectChangesEnabled;
            this.Context.Configuration.ProxyCreationEnabled = proxyCreationEnabled;
        }

        public TEntity Create<TEntity>(TEntity newEntity) where TEntity : class
        {
            TEntity Result = null;

            try
            {
                Result = Context.Set<TEntity>().Add(newEntity);
                TrySaveChanges();
            }
            catch (Exception e)
            {

                throw (e);
            }

            return Result;
        }

        private int TrySaveChanges()
        {
            return Context.SaveChanges();
        }

        public bool Delete<TEntity>(TEntity deletedEntity) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public TEntity FindEntity<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> FindEntitySet<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public bool Update<TEntity>(TEntity modifiedEntity) where TEntity : class
        {
            throw new NotImplementedException();
        }
    }
}
