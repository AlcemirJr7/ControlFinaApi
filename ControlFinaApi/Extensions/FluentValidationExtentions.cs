using FluentValidation;

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
