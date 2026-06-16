using Application.Common.Behavior;
using Application.Features.Bonuses.Factories;
using Application.Features.Brands.Command.CreateBrand;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection.Metadata;

namespace Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(CreateBrandCommandHandler).Assembly);
            });

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddScoped<IEmployeeBonusEligibilitySpecificationFactory, EmployeeBonusEligibilitySpecificationFactory>();

            return services;
        }
    }
}
