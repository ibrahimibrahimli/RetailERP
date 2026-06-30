using Application.Features.Bonuses.DTOs;
using Domain.Entities;
using Domain.Enums;

namespace Application.Features.Bonuses.Strategies
{
    public class FixedBonusStrategy : IBonusStrategy
    {
        public BonusCalculationResult Calculate(BonusCalculationContext context, IEnumerable<BonusRule> rules)
        {
            var rule = rules
                .Where(x => x.BonusType == BonusType.Fixed)
                .Where(x => x.PositionId == context.PositionId)
                .FirstOrDefault(x => context.PersonalSales >= x.MinimumSales &&
                (!x.MaximumSales.HasValue || context.PersonalSales <= x.MinimumSales));

            if (rule is null)
                return new(BonusType.Fixed, 0);

            return new(BonusType.Fixed, rule.BonusValue);
        }
    }
}
