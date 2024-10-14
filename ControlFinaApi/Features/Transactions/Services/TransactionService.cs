using ControlFinaApi.Entities;
using ControlFinaApi.Features.Transactions.Contracts.Requests;
using ControlFinaApi.Features.Transactions.Repositories.Commands;
using ControlFinaApi.Features.Transactions.Contracts.Responses;
using ControlFinaApi.Features.Transactions.Mappings;
using ControlFinaApi.Extensions;
using ControlFinaApi.Features.Transactions.Repositories.Queries;
using ControlFinaApi.Messages;
using ControlFinaApi.Features.Histories.Repositories.Queries;
using ControlFinaApi.Features.Transactions.Validators;

namespace ControlFinaApi.Features.Transactions.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionCommandRepository _command;
        private readonly ITransactionQueryRepository _query;
        private readonly IHistoryQueryRepository _historicoQuery;


        public TransactionService(ITransactionQueryRepository query,
                                  ITransactionCommandRepository command,
                                  IHistoryQueryRepository historicoQuery)
        {
            _query = query;
            _command = command;
            _historicoQuery = historicoQuery;
        }

        public async Task<Result<TransactionResponse>> CreateAsync(CreateTransactionRequest request)
        {
            var validator = new CreateTransactionValidator();
            var resultErros = validator.Validate(request);
            var errors = resultErros.GetErrors();

            if (errors.Any())
                return Result<TransactionResponse>.Failure(errors);

            History? history = await _historicoQuery.GetByIdAsync(request.HistoryId);

            if (history is null)
                return Result<TransactionResponse>.Failure(ResponseErrorsMessages.NotFound(nameof(History), request.HistoryId));

            Transaction transaction = new(request.TransactionDate.ToDateOnlyIso(), request.HistoryId, request.Value);

            _command.Create(transaction);
            var commit = await _command.Commit();

            if (commit != 1)
                return Result<TransactionResponse>.Failure(ResponseErrorsMessages.Command("Create", nameof(Transaction)));

            var result = TransactionMapping.ToResponse(transaction);

            return Result<TransactionResponse>.SuccessCreate(result);
        }

        public async Task<Result<TransactionResponse>> UpdateAsync(UpdateTransactionRequest request)
        {
            var validator = new UpdateTransactionValidator();
            var resultErros = validator.Validate(request);
            var errors = resultErros.GetErrors();

            if (errors.Any())
                return Result<TransactionResponse>.Failure(errors);

            History? history = await _historicoQuery.GetByIdAsync(request.HistoryId);

            if (history is null)
                return Result<TransactionResponse>.Failure(ResponseErrorsMessages.NotFound(nameof(History), request.HistoryId));

            Transaction? transaction = await _query.GetByIdAsync(request.Id);

            if (transaction is null)
                return Result<TransactionResponse>.Failure(ResponseErrorsMessages.NotFound(nameof(Transaction), request.Id));

            transaction.Update(request);

            _command.Update(transaction);
            var commit = await _command.Commit();

            if (commit != 1)
                return Result<TransactionResponse>.Failure(ResponseErrorsMessages.Command("Update", nameof(Transaction)));

            var result = TransactionMapping.ToResponse(transaction);

            return Result<TransactionResponse>.Success(result);

        }

        public async Task<Result<TransactionResponse>> DeleteAsync(Guid id)
        {
            Transaction? transaction = await _query.GetByIdAsync(id);

            if (transaction is null)
                return Result<TransactionResponse>.Failure(ResponseErrorsMessages.NotFound(nameof(Transaction), id));

            _command.Delete(transaction);
            var commit = await _command.Commit();

            if (commit != 1)
                return Result<TransactionResponse>.Failure(ResponseErrorsMessages.Command("Delete", nameof(Transaction)));

            var result = TransactionMapping.ToResponse(transaction);

            return Result<TransactionResponse>.Success(result);
        }

        public async Task<Result<IEnumerable<TransactionResponse>>> GetAllAsync()
        {
            var transactions = await _query.GetAllAsync();

            if (transactions is null)
                return Result<IEnumerable<TransactionResponse>>.Success([]);

            var result = TransactionMapping.ToResponse(transactions);

            return Result<IEnumerable<TransactionResponse>>.Success(result);
        }

        public async Task<Result<TransactionResponse>> GetByIdAsync(Guid id)
        {
            var transaction = await _query.GetByIdAsync(id);

            if (transaction is null)
                return Result<TransactionResponse>.NotFound(ResponseErrorsMessages.NotFound(nameof(Transaction), id));

            var result = TransactionMapping.ToResponse(transaction);

            return Result<TransactionResponse>.Success(result);
        }
    }
}
