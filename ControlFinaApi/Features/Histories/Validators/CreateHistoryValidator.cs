using ControlFinaApi.Extensions;
using ControlFinaApi.Features.Histories.Contracts.Requests;
using ControlFinaApi.Features.Histories.Enums;
using ControlFinaApi.Messages;
using FluentValidation;

namespace ControlFinaApi.Features.Histories.Validators
{
    public class CreateHistoryValidator : AbstractValidator<CreateHistoryRequest>
    {
        private int _maxLengthDescription = 200;
        public CreateHistoryValidator()
        {
            RuleFor(history => history.Description)
            .NotNullOrEmpty().WithMessage(ValidatorErrorsMessages.NullOrEmpty("Description"))
            .MaximumLength(_maxLengthDescription).WithMessage(ValidatorErrorsMessages.MaxLength("Description", _maxLengthDescription));

            RuleFor(history => history.Type)
            .IsInEnum().WithMessage($"type field is invalid, it must be " +
                                    $"{ETypeHistory.Credit}: {(int)ETypeHistory.Credit} or " +
                                    $"{ETypeHistory.Debit}: {(int)ETypeHistory.Debit}");
        }
    }
}
