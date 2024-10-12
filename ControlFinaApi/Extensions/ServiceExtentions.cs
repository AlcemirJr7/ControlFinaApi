using ControlFinaApi.Features.Histories.Services;
using ControlFinaApi.Features.Transactions.Services;

namespace ControlFinaApi.Extensions
{
    public static class ServiceExtentions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IHistoryService, HistoryService>();
            services.AddScoped<ITransactionService, TransactionService>();

            return services;
        }
    }
}
