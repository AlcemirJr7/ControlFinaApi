using ControlFinaApi.Features.Histories.Contracts.Requests;
using ControlFinaApi.Features.Histories.Contracts.Responses;

namespace ControlFinaApi.Features.Histories.Services
{
    public interface IHistoryService
    {
        Task<Result<HistoryResponse>> CreateAsync(CreateHistoryRequest request);
        Task<Result<HistoryResponse>> UpdateAsync(UpdateHistoryRequest request);
        Task<Result<HistoryResponse>> DeleteAsync(Guid id);
        Task<Result<IEnumerable<HistoryResponse>>> GetAllAsync();
        Task<Result<HistoryResponse>> GetByIdAsync(Guid id);

    }
}
