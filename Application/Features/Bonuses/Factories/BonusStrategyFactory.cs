using Application.Features.Bonuses.Strategies;
using Domain.Enums;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Features.Bonuses.Factories
{
    public sealed class BonusStrategyFactory : IBonusStrategyFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public BonusStrategyFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IBonusStrategy Create(BonusType type)
        {
            return type switch
            {
                BonusType.Fixed => _serviceProvider.GetRequiredService<FixedBonusStrategy>(),

                _ => throw new NotSupportedException($"Bonus type '{type}' not supported")
            };
        }
    }
}
