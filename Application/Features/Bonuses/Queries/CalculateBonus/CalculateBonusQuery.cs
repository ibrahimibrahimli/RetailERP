using Application.Common.Results;
using Application.Features.Bonuses.DTOs;
using MediatR;

namespace Application.Features.Bonuses.Queries.CalculateBonus
{
    public sealed record CalculateBonusQuery(
        Guid EmployeeId,
        int Year,
        int Month) : IRequest<Result<BonusCalculationResult>>;
}
