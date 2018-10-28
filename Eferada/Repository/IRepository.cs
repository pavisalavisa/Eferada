namespace Eferada.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Create();

        TEntity Add(TEntity entity);

        TEntity Remove(TEntity entity);

        TEntity Update(TEntity entity);

    }
}
