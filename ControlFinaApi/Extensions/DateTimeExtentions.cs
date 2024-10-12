namespace ControlFinaApi.Extensions
{
    public static class DateTimeExtentions
    {
        public static string ToDateOnlyIso(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd");
        }
    }
}
