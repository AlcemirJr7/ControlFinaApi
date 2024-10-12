using ControlFinaApi.Features.Histories.Contracts.Requests;
using ControlFinaApi.Features.Histories.Enums;

namespace ControlFinaApi.Entities
{
    public class History
    {
        public Guid Id { get; private set; }
        public string Description { get; private set; } = string.Empty;
        public ETypeHistory Type { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public History(string description, ETypeHistory type)
        {
            Id = Guid.NewGuid();
            Description = description;
            Type = type;
            CreatedAt = DateTime.UtcNow;
        }

        public void Update(string description, ETypeHistory type)
        {
            Description = description;
            Type = type;
        }

        public void Update(UpdateHistoryRequest request)
        {
            Description = request.Description;
            Type = request.Type;
        }

    }
}
