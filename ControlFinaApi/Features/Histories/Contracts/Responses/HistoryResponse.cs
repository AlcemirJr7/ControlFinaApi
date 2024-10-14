using ControlFinaApi.Features.Histories.Enums;

namespace ControlFinaApi.Features.Histories.Contracts.Responses
{
    public class HistoryResponse
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public TypeHistory.EType Type { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
