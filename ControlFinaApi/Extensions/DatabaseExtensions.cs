using ControlFinaApi.Database;
using Microsoft.EntityFrameworkCore;

namespace ControlFinaApi.Extensions
{
    public static class DatabaseExtensions
    {
        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<AppDbContext>(context =>
                        context.UseNpgsql(configuration.GetConnectionString("Database")));
        }
    }
}
