using Application.Features.Bonuses.DTOs;
using Domain.Entities;
using Domain.Enums;

namespace Application.Features.Bonuses.Strategies
{
    public sealed class PercentageBonusStrategies : IBonusStrategy
    {
        public BonusCalculationResult Calculate(BonusCalculationContext context, IEnumerable<BonusRule> rules)
        {
            var rule = rules
                .Where(x => x.BonusType == BonusType.Percentage)
                .Where(x => x.PositionId == context.PositionId)
                .OrderByDescending(x => x.MinimumSales)
                .FirstOrDefault(x =>
                     context.PersonalSales >= x.MinimumSales &&
                     (x.MaximumSales.HasValue || context.PersonalSales <= x.MaximumSales));

            if (rule is null)
                return new(BonusType.Percentage, 0);

            var bonusAmount = context.PersonalSales * rule.BonusValue / 100;

            return new(BonusType.Percentage, bonusAmount);
        }
    }
}
