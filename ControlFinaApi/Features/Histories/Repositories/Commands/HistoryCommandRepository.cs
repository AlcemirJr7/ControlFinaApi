using ControlFinaApi.Database;
using ControlFinaApi.Entities;
using ControlFinaApi.RepositoryAbstraction;

namespace ControlFinaApi.Features.Histories.Repositories.Commands
{
    public class HistoryCommandRepository : CommandRepository<History>, IHistoryCommandRepository
    {
        public HistoryCommandRepository(AppDbContext context) : base(context)
        {
        }
    }
}
