using Domain.Enums;

namespace Application.Features.Bonuses.DTOs
{
    public sealed record class BonusCalculationResult(
        BonusType BonusType,
        decimal BonusAmount);
}
