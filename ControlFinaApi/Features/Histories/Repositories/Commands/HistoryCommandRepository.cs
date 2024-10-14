using ControlFinaApi.Abstractions.Repository;
using ControlFinaApi.Database;
using ControlFinaApi.Entities;

namespace ControlFinaApi.Features.Histories.Repositories.Commands
{
    public class HistoryCommandRepository : CommandRepository<History>, IHistoryCommandRepository
    {
        public HistoryCommandRepository(AppDbContext context) : base(context)
        {
        }
    }
}
