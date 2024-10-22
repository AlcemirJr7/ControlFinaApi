using ControlFinaApi.Database;
using ControlFinaApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControlFinaApi.Features.Histories.Repositories.Queries
{
    public class HistoryQueryRepository : IHistoryQueryRepository
    {
        private readonly AppDbContext _context;
        public HistoryQueryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<History>?> GetAllAsync()
        {
            IEnumerable<History>? histories = await _context.Histories
                                                            .AsNoTracking()
                                                            .OrderBy(h => h.Description)
                                                            .ToListAsync();

            return histories;
        }

        public async Task<History?> GetByIdAsync(Guid id)
        {
            History? history = await _context.Histories
                                             .AsNoTracking()
                                             .Where(hist => hist.Id == id)
                                             .FirstOrDefaultAsync();
            return history;


        }
    }
}
