using Domain.Enums;

namespace Application.Features.BonusRules.DTOs
{
    public sealed record class BonusRuleDto(
        Guid Id,
        Guid PositionId,
        string PositionName,
        BonusType BonusType,
        decimal MinimumSales,
        decimal? MaximumSales,
        decimal BonusValue,
        DateOnly EffectiveFrom,
        DateOnly? EffectiveTo,
        bool IsActive,
        int? Rank);
}
