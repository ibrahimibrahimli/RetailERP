using Application.Common.Results;
using Application.Features.BonusRules.DTOs;
using MediatR;

namespace Application.Features.BonusRules.Queries.GetBonusRuleById
{
    public sealed record class GetBonusRuleByIdQuery(Guid Id) : IRequest<Result<BonusRuleDetailsDto>>;
}
