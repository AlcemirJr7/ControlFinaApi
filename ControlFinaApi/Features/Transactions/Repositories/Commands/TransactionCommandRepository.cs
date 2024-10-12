using ControlFinaApi.Database;
using ControlFinaApi.Entities;
using ControlFinaApi.RepositoryAbstraction;

namespace ControlFinaApi.Features.Transactions.Repositories.Commands
{
    public class TransactionCommandRepository : CommandRepository<Transaction>, ITransactionCommandRepository
    {
        public TransactionCommandRepository(AppDbContext context) : base(context)
        {
        }
    }
}
