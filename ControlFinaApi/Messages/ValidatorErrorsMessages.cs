using ControlFinaApi.Extensions;

namespace ControlFinaApi.Messages
{
    public static class ValidatorErrorsMessages
    {
        public static string NullOrEmpty(string fieldName) => $"{fieldName.ToLowerCamelCase()} field can't be null or empty.";

        public static string MaxLength(string fieldName, int length) => $"{fieldName.ToLowerCamelCase()} field must be maximum length {length}.";

        public static string ValueGreaterThan(string fieldName, double value) => $"{fieldName.ToLowerCamelCase()} field must be greater then {value}.";

        public static string InvalidDateFormat(string fieldName) => $"{fieldName.ToLowerCamelCase()} field is invalid, must be in the format yyyy-MM-dd.";

    }
}
