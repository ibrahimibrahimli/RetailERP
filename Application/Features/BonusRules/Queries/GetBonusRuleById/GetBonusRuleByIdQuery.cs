using Application.Common.Results;
using Domain.Entities;
using MediatR;

namespace Application.Features.BonusRules.Queries.GetBonusRuleById
{
    public sealed record class GetBonusRuleByIdQuery(Guid Id) : IRequest<Result<BonusRule>>;
}
