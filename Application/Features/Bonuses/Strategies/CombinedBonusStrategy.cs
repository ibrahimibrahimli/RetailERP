using Application.Features.Bonuses.DTOs;
using Domain.Entities;
using Domain.Enums;

namespace Application.Features.Bonuses.Strategies
{
    public sealed class CombinedBonusStrategy : IBonusStrategy
    {
        private readonly FixedBonusStrategy _fixedBonusStrategy;

        public CombinedBonusStrategy(FixedBonusStrategy fixedBonusStrategy)
        {
            _fixedBonusStrategy = fixedBonusStrategy;
        }

        public BonusCalculationResult Calculate(BonusCalculationContext context, IEnumerable<BonusRule> rules)
        {
            var personalRules = rules.Where(x => x.BonusScope == BonusScope.Personal);

            var storeRules = rules.Where(x => x.BonusScope == BonusScope.Store);

            var personalResult = _fixedBonusStrategy.Calculate(context with
            {
                PersonalSales = context.PersonalSales
            },
            personalRules);

            var storeResult = _fixedBonusStrategy.Calculate(context with
            {
                PersonalSales = context.StoreSales
            },
            storeRules);

            decimal fixedAmount = personalResult.BonusAmount + storeResult.BonusAmount;
            return new(BonusType.Combined, fixedAmount);
        }
    }
}
