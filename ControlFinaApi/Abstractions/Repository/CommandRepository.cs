using ControlFinaApi.Database;

namespace ControlFinaApi.Abstractions.Repository
{
    public class CommandRepository<TEntity> : ICommandRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext _context;

        public CommandRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }

        public async Task<int> Commit()
        {
            return await _context.SaveChangesAsync();
        }

        public void Rollback()
        {
            _context.ChangeTracker.Entries().ToList().ForEach(entry => entry.Reload());
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
