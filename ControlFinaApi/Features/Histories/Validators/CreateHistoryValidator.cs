using ControlFinaApi.Extensions;
using ControlFinaApi.Features.Histories.Contracts.Requests;
using ControlFinaApi.Messages;
using FluentValidation;

namespace ControlFinaApi.Features.Histories.Validators
{
    public class CreateHistoryValidator : AbstractValidator<CreateHistoryRequest>
    {
        public CreateHistoryValidator()
        {
            RuleFor(history => history.Description)
            .NotNullOrEmpty().WithMessage(ValidatorErrorsMessages.NullOrEmpty("Description"))
            .MaximumLength(HistoryConsts.MAX_LENGTH_DESCRIPTION).WithMessage(ValidatorErrorsMessages.MaxLength("Description", HistoryConsts.MAX_LENGTH_DESCRIPTION));

            RuleFor(history => history.Type)
            .IsInEnum().WithMessage(HistoryErrors.Type);
        }
    }
}
