using ControlFinaApi.Features.Histories.Enums;

namespace ControlFinaApi.Features.Histories.Contracts.Requests
{
    public class CreateHistoryRequest
    {
        public string Description { get; set; } = string.Empty;
        public ETypeHistory Type { get; set; }
    }
}
