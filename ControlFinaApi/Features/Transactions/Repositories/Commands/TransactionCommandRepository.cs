using ControlFinaApi.Abstractions.Repository;
using ControlFinaApi.Database;
using ControlFinaApi.Entities;

namespace ControlFinaApi.Features.Transactions.Repositories.Commands
{
    public class TransactionCommandRepository : CommandRepository<Transaction>, ITransactionCommandRepository
    {
        public TransactionCommandRepository(AppDbContext context) : base(context)
        {
        }
    }
}
