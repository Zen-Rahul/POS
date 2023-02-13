using Microsoft.EntityFrameworkCore;
using POS.Api.Data;
using POS.Api.Data.Enums;
using POS.Api.Repositories.Interfaces;

namespace POS.Api.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly POSContext Context;
        private readonly DbSet<T> _dbSet;

        public Repository(POSContext context)
        {
            Context = context;
            _dbSet = context.Set<T>();
        }

        public async virtual Task<T> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async virtual Task Add(T entity)
        {
           _ = await _dbSet.AddAsync(entity);
        }

        public async virtual Task Delete(int id)
        {
            T entityToDelete = await _dbSet.FindAsync(id);
            await Delete(entityToDelete);
        }

        public async virtual Task Delete(T entityToDelete)
        {
            await Task.Run(() =>
            {
                if (Context.Entry(entityToDelete).State == EntityState.Detached)
                {
                    _dbSet.Attach(entityToDelete);
                }
                _dbSet.Remove(entityToDelete);
            });
        }

        public async virtual Task Update(T entityToUpdate)
        {
            await Task.Run(() =>
            {
                _dbSet.Attach(entityToUpdate);
                Context.Entry(entityToUpdate).State = EntityState.Modified;
            });
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await Task.Run(() => _dbSet);
        }

        #region IDisposable Implementation
        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        } 
        #endregion

    }
}
