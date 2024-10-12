using FluentValidation.Results;

namespace ControlFinaApi.Utils
{
    public static class ValidateErros
    {
        public static IEnumerable<string> GetErros(ValidationResult? validationResult)
        {
            if (validationResult is not null)
            {

                if (!validationResult.IsValid)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        yield return error.ErrorMessage;

                    }
                }
            }
        }
    }
}
