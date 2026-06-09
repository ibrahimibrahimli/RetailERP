using Application.Interfaces.Repositories.Read.Common;
using Application.Interfaces.Repositories.Write.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Context;
using Persistance.Repositories.Read.Common;
using Persistance.Repositories.Write.Common;

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

            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

            services.AddScoped<IBrandReadRepository, BrandReadRepository>();
            services.AddScoped<IBrandWriteRepository, BrandWriteRepository>();

            services.AddScoped<ISubCompanyWriteRepository, SubCompanyWriteRepository>();
            services.AddScoped<ISubCompanyReadRepository, SubCompanyReadRepository>();

            services.AddScoped<IBranchWriteRepository, BranchWriteRepository>();
            services.AddScoped<IBranchReadRepository, BranchReadRepository>();

            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();

            services.AddScoped<IBranchInventoryWriteRepository, BranchInventoryWriteRepository>();
            services.AddScoped<IBranchInventoryReadRepository, BranchInventoryReadRepository>();

            services.AddScoped<IInventoryTransactionWriteRepository, InventoryTransactionWriteRepository>();
            services.AddScoped<IInventoryTransactionReadRepository, InventoryTransactionReadRepository>();

            services.AddScoped<ISaleReadRepository, SaleReadRepository>();

            services.AddScoped<ISaleWriteRepository, SaleWriteRepository>();

            services.AddScoped<IProductVariantReadRepository, ProductVariantReadRepository>();
            services.AddScoped<IProductVariantWriteRepository, ProductVariantWriteRepository>();

            services.AddScoped<IEmployeeReadRepository, EmployeeReadRepository>();
            services.AddScoped<IEmployeeWriteRepository, EmployeeWriteRepository>();

            services.AddScoped<IPositionReadRepository, PositionReadRepository>();
            services.AddScoped<IPositionWriteRepository, PositionWriteRepository>();

            return services;
        }
    }
}
