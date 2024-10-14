using ControlFinaApi.Features.Histories.Enums;

namespace ControlFinaApi.Features.Histories.Validators
{
    public static class HistoryErrors
    {
        public static string Type => $"type field is invalid, it must be {TypeHistory.GetEnumDescriptionValues()}";
    }
}
