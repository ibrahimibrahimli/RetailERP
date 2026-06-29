using Application.Features.Bonuses.Strategies;
using Domain.Enums;

namespace Application.Features.Bonuses.Factories
{
    public interface IBonusStrategyFactory
    {
        IBonusStrategy Create(BonusType type);
    }
}
