using ControlFinaApi.Extensions;
using ControlFinaApi.Features.Transactions.Contracts.Requests;
using ControlFinaApi.Messages;
using ControlFinaApi.Utils;
using FluentValidation;

namespace ControlFinaApi.Features.Transactions.Validators
{
    public class UpdateTransactionValidator : AbstractValidator<UpdateTransactionRequest>
    {
        public UpdateTransactionValidator()
        {
            RuleFor(transaction => transaction.Id)
            .NotNullOrEmpty().WithMessage(ValidatorErrorsMessages.NullOrEmpty("Id"));

            RuleFor(transaction => transaction.TransactionDate)
                .NotNullOrEmpty().WithMessage(ValidatorErrorsMessages.NullOrEmpty("TransactionDate"))
                .Must(DateUtil.isValidDate).WithMessage(ValidatorErrorsMessages.InvalidDateFormat("TransactionDate"));

            RuleFor(transaction => transaction.HistoryId)
            .NotNullOrEmpty().WithMessage(ValidatorErrorsMessages.NullOrEmpty("HistoryId"));

            RuleFor(transaction => transaction.Value)
            .GreaterThan(0).WithMessage(ValidatorErrorsMessages.ValueGreaterThan("Value", 0));
        }
    }
}
