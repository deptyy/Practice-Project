using System.Linq.Expressions;

namespace WebApplicationDemo2.Repository.Interface
{
    public interface IGenericRepo<TEntity> where TEntity : class
    {
        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
