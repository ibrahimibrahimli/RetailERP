using Application.Features.Bonuses.DTOs;
using Domain.Entities;
using Domain.Enums;

namespace Application.Features.Bonuses.Strategies
{
    public sealed class TopNBonusStrategies : IBonusStrategy
    {
        public BonusCalculationResult Calculate(BonusCalculationContext context, IEnumerable<BonusRule> rules)
        {
            var rankings = context.EmployeeRankings
                .OrderByDescending(x => x.PersonalSales)
                .ToList();



            var rank = rankings.FindIndex(
                x => x.EmployeeId == context.EmployeeId) + 1;

            if (rank <= 0)
                return new BonusCalculationResult(BonusType.TopN, 0);

            var rule = rules
                .Where(x => x.BonusType == BonusType.TopN)
                .Where(x => x.Rank == rank)
                .FirstOrDefault();

            if(rule is null)
                return new BonusCalculationResult(BonusType.TopN, 0);

            return new(BonusType.TopN, rule.BonusValue);
        }
    }
}
