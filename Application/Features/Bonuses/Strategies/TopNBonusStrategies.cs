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

            var employeeIndex = rankings.FindIndex(
                x => x.EmployeeId == context.EmployeeId);

            if (employeeIndex < 0)
                return new BonusCalculationResult(BonusType.TopN, 0);

            var rule = rules
                .Where(x => x.BonusType == BonusType.TopN)
                .OrderBy(x => x.MinimumSales)
                .Skip(employeeIndex)
                .FirstOrDefault();

            if(rule is null)
                return new BonusCalculationResult(BonusType.TopN, 0);

            return new(BonusType.TopN, rule.BonusValue);
        }
    }
}
