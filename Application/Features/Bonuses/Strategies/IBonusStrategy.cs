using Application.Features.Bonuses.DTOs;
using Domain.Entities;

namespace Application.Features.Bonuses.Strategies
{
    public interface IBonusStrategy
    {
        BonusCalculationResult Calculate(BonusCalculationContext context, IEnumerable<BonusRule> rules);
    }
}
