using ControlFinaApi.Database;
using ControlFinaApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControlFinaApi.Features.Transactions.Repositories.Queries
{
    public class TransactionQueryRepository : ITransactionQueryRepository
    {
        private readonly AppDbContext _context;
        public TransactionQueryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Transaction>?> GetAllAsync()
        {
            IEnumerable<Transaction>? transacaos = await _context.Transactions
                                                               .AsNoTracking()
                                                               .ToListAsync();

            return transacaos;
        }

        public async Task<Transaction?> GetByIdAsync(Guid id)
        {
            Transaction? transaction = await _context.Transactions
                                                 .AsNoTracking()
                                                 .Where(hist => hist.Id == id)
                                                 .FirstOrDefaultAsync();
            return transaction;
        }
    }
}
