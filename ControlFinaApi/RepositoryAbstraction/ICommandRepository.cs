namespace ControlFinaApi.RepositoryAbstraction
{
    public interface ICommandRepository<TEntity> : IDisposable where TEntity : class
    {
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task<int> Commit();
        void Rollback();
    }
}
