using ControlFinaApi.Features.Histories.Enums;

namespace ControlFinaApi.Features.Histories.Contracts.Requests
{
    public class UpdateHistoryRequest
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public ETypeHistory Type { get; set; }

    }
}
