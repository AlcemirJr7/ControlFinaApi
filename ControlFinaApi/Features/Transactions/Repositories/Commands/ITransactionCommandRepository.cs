using ControlFinaApi.Entities;
using ControlFinaApi.RepositoryAbstraction;

namespace ControlFinaApi.Features.Transactions.Repositories.Commands
{
    public interface ITransactionCommandRepository : ICommandRepository<Transaction>
    {
    }
}
