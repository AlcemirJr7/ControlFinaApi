using ControlFinaApi.Features.Histories.Contracts.Requests;
using ControlFinaApi.Entities;
using ControlFinaApi.Features.Histories.Mappings;
using ControlFinaApi.Features.Histories.Repositories.Commands;
using ControlFinaApi.Utils;
using ControlFinaApi.Messages;
using ControlFinaApi.Features.Histories.Contracts.Responses;
using ControlFinaApi.Features.Histories.Repositories.Queries;
using ControlFinaApi.Features.Histories.Validators;
using ControlFinaApi.Extensions;

namespace ControlFinaApi.Features.Histories.Services
{
    public class HistoryService : IHistoryService
    {

        private readonly IHistoryCommandRepository _command;
        private readonly IHistoryQueryRepository _query;
        public HistoryService(IHistoryQueryRepository query, IHistoryCommandRepository command)
        {
            _query = query;
            _command = command;
        }

        public async Task<Result<HistoryResponse>> CreateAsync(CreateHistoryRequest request)
        {
            var validator = new CreateHistoryValidator();
            var resultErros = validator.Validate(request);
            var errors = resultErros.GetErrors();

            if (errors.Any())
                return Result<HistoryResponse>.Failure(errors);

            History history = new(request.Description, request.Type);

            _command.Create(history);
            var commit = await _command.Commit();

            if (commit != 1)
                return Result<HistoryResponse>.Failure(ResponseErrorsMessages.Command("Create", nameof(History)));

            var result = HistoryMapping.ToResponse(history);

            return Result<HistoryResponse>.SuccessCreate(result);

        }

        public async Task<Result<HistoryResponse>> UpdateAsync(UpdateHistoryRequest request)
        {
            var validator = new UpdateHistoryValidator();
            var resultErros = validator.Validate(request);
            var errors = resultErros.GetErrors();

            if (errors.Any())
                return Result<HistoryResponse>.Failure(errors);

            History? history = await _query.GetByIdAsync(request.Id);

            if (history is null)
                return Result<HistoryResponse>.Failure(ResponseErrorsMessages.NotFound(nameof(History), request.Id));

            history.Update(request);

            _command.Update(history);
            var commit = await _command.Commit();

            if (commit != 1)
                return Result<HistoryResponse>.Failure(ResponseErrorsMessages.Command("Update", nameof(History)));

            var result = HistoryMapping.ToResponse(history);

            return Result<HistoryResponse>.Success(result);

        }

        public async Task<Result<HistoryResponse>> DeleteAsync(Guid id)
        {

            History? history = await _query.GetByIdAsync(id);

            if (history is null)
                return Result<HistoryResponse>.Failure(ResponseErrorsMessages.NotFound(nameof(History), id));

            _command.Delete(history);
            var commit = await _command.Commit();

            if (commit != 1)
                return Result<HistoryResponse>.Failure(ResponseErrorsMessages.Command("Delete", nameof(History)));

            var result = HistoryMapping.ToResponse(history);

            return Result<HistoryResponse>.Success(result);
        }

        public async Task<Result<IEnumerable<HistoryResponse>>> GetAllAsync()
        {

            var histories = await _query.GetAllAsync();

            if (histories is null)
                return Result<IEnumerable<HistoryResponse>>.Success([]);

            var result = HistoryMapping.ToResponse(histories);

            return Result<IEnumerable<HistoryResponse>>.Success(result);
        }

        public async Task<Result<HistoryResponse>> GetByIdAsync(Guid id)
        {
            var history = await _query.GetByIdAsync(id);

            if (history is null)
                return Result<HistoryResponse>.NotFound(ResponseErrorsMessages.NotFound(nameof(History), id));

            var result = HistoryMapping.ToResponse(history);

            return Result<HistoryResponse>.Success(result);
        }

    }
}
