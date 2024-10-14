using ControlFinaApi.Abstractions.Repository;
using ControlFinaApi.Entities;

namespace ControlFinaApi.Features.Transactions.Repositories.Commands
{
    public interface ITransactionCommandRepository : ICommandRepository<Transaction>
    {
    }
}
