using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Context;

namespace Persistance.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RetailERPDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("PostgreSql"));
            });

            return services;
        }
    }
}
