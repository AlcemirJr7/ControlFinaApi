using ControlFinaApi.Features.Histories.Repositories.Commands;
using ControlFinaApi.Features.Histories.Repositories.Queries;
using ControlFinaApi.Features.Transactions.Repositories.Commands;
using ControlFinaApi.Features.Transactions.Repositories.Queries;

namespace ControlFinaApi.Extensions
{
    public static class RepositoryExtentions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            // Commands
            services.AddScoped<IHistoryCommandRepository, HistoryCommandRepository>();
            services.AddScoped<ITransactionCommandRepository, TransactionCommandRepository>();

            // Queries
            services.AddScoped<IHistoryQueryRepository, HistoryQueryRepository>();
            services.AddScoped<ITransactionQueryRepository, TransactionQueryRepository>();

            return services;
        }
    }
}
