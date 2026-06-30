using Application.Common.Results;
using Application.Features.Bonuses.DTOs;
using MediatR;

namespace Application.Features.Bonuses.Queries.CheckBonusEligibility
{
    public sealed record CheckBonusEligibilityQuery(
        Guid EmployeeId,
        int Year,
        int Month) : IRequest<Result<BonusEligibilityDto>>;
}
