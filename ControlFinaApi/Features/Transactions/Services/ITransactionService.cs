using ControlFinaApi.Features.Transactions.Contracts.Requests;
using ControlFinaApi.Features.Transactions.Contracts.Responses;

namespace ControlFinaApi.Features.Transactions.Services
{
    public interface ITransactionService
    {
        Task<Result<TransactionResponse>> CreateAsync(CreateTransactionRequest request);
        Task<Result<TransactionResponse>> UpdateAsync(UpdateTransactionRequest request);
        Task<Result<TransactionResponse>> DeleteAsync(Guid id);
        Task<Result<IEnumerable<TransactionResponse>>> GetAllAsync();
        Task<Result<TransactionResponse>> GetByIdAsync(Guid id);
    }
}
