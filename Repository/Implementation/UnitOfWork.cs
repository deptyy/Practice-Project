using System.Collections;
using WebApplicationDemo2.Data;
using WebApplicationDemo2.Repository.Interface;

namespace WebApplicationDemo2.Repository.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed;
        private Hashtable _repositories;
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            this._context = context;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                _disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IGenericRepo<TEntity> GenericRepo<TEntity>() where TEntity : class
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepo<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
                _repositories.Add(type, repositoryInstance);
            }

            return (IGenericRepo<TEntity>)_repositories[type];
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
