using ControlFinaApi.Entities;

namespace ControlFinaApi.Features.Transactions.Repositories.Queries
{
    public interface ITransactionQueryRepository
    {
        Task<IEnumerable<Transaction>?> GetAllAsync();
        Task<Transaction?> GetByIdAsync(Guid id);

    }
}
