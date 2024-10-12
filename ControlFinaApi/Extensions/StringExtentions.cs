using System.Globalization;

namespace ControlFinaApi.Extensions
{
    public static class StringExtentions
    {
        public static DateTime ToDateOnlyIso(this string date)
        {
            return DateTime.Parse(date).Date.ToUniversalTime();
        }

        public static string ToLowerCamelCase(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            // Splits words based on spaces
            var words = input.Split(new[] { ' ', '_' }, StringSplitOptions.RemoveEmptyEntries);

            // Keep the first word with the first letter lowercase
            var camelCaseString = words[0].ToLower();

            // Capitalize the first letters of subsequent words
            for (int i = 1; i < words.Length; i++)
            {
                camelCaseString += CultureInfo.CurrentCulture.TextInfo.ToTitleCase(words[i].ToLower());
            }

            return camelCaseString;
        }
    }
}
