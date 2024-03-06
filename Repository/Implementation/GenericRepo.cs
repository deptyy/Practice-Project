using Microsoft.EntityFrameworkCore;
using WebApplicationDemo2.Data;
using WebApplicationDemo2.Repository.Interface;

namespace WebApplicationDemo2.Repository.Implementation
{
    public class GenericRepo<TEntity> : IGenericRepo<TEntity> where TEntity : class
    {
        private readonly DataContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;
        public GenericRepo(DataContext dbContext)
        {
            this._dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();


        }
        public async Task Add(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetById(int id) => await _dbSet.FindAsync(id);

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }
    }
}
