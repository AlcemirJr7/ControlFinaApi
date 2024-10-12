using System.Text.RegularExpressions;

namespace ControlFinaApi.Utils
{
    public static class DateUtil
    {
        public static bool isValidDate(string date)
        {
            string datePattern = @"^\d{4}-\d{2}-\d{2}$";
            var isMatch = Regex.IsMatch(date, datePattern);
            var canParse = DateTime.TryParse(date, out _);
            return isMatch && canParse;
        }

        public static bool isValidDate(DateTime date)
        {
            return DateTime.TryParse(date.ToString(), out _);
        }
    }
}
