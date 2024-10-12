using ControlFinaApi.Entities;
using ControlFinaApi.Features.Histories.Contracts.Responses;

namespace ControlFinaApi.Features.Histories.Mappings
{
    public class HistoryMapping
    {
        public static HistoryResponse ToResponse(History history)
        {
            return new HistoryResponse
            {
                Id = history.Id,
                Description = history.Description,
                Type = history.Type,
                CreatedAt = history.CreatedAt
            };
        }

        public static IEnumerable<HistoryResponse> ToResponse(IEnumerable<History> histories)
        {

            foreach (var history in histories)
            {
                yield return new HistoryResponse
                {
                    Id = history.Id,
                    Description = history.Description,
                    Type = history.Type,
                    CreatedAt = history.CreatedAt
                };
            }
        }
    }
}
