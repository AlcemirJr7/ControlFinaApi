using FluentValidation;
using FluentValidation.Results;

namespace ControlFinaApi.Extensions
{
    public static class FluentValidationExtentions
    {
        public static IRuleBuilderOptions<T, string> NotNullOrEmpty<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must(IsNullOrEmpty);
        }

        public static IRuleBuilderOptions<T, Guid> NotNullOrEmpty<T>(this IRuleBuilder<T, Guid> ruleBuilder)
        {
            return ruleBuilder.Must(IsNullOrEmpty);
        }

        public static IEnumerable<string> GetErrors(this ValidationResult validationResult)
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
        private static bool IsNullOrEmpty(string input)
        {
            return !string.IsNullOrEmpty(input.Trim());
        }

        private static bool IsNullOrEmpty(Guid input)
        {
            return !string.IsNullOrEmpty(input.ToString().Trim());
        }

    }
}
