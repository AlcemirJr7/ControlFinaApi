using ControlFinaApi.Entities;

namespace ControlFinaApi.Features.Histories.Repositories.Queries
{
    public interface IHistoryQueryRepository
    {
        Task<IEnumerable<History>?> GetAllAsync();
        Task<History?> GetByIdAsync(Guid id);
    }
}
