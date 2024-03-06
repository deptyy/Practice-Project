

namespace WebApplicationDemo2.Repository.Interface
{
    public interface IUnitOfWork : IDisposable

    {
        IGenericRepo<TEntity> GenericRepo<TEntity>() where TEntity : class;
        Task<int> Save();
    }
}
