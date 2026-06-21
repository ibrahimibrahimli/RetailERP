using Application.Common.Results;
using Domain.Enums;
using MediatR;

namespace Application.Features.BonusRules.Commands
{
    public sealed record CreateBonusRuleCommand(
        Guid PositionId,
        BonusType BonusType,
        decimal MinimumSales,
        decimal? MaximumSales,
        decimal BonusValue,
        DateOnly EffectiveFrom,
        DateOnly? EffectiveTo) : IRequest<Result>;
}
