using Application.Common.Results;
using Application.Features.BonusRules.DTOs;
using MediatR;

namespace Application.Features.BonusRules.Queries.GetAllBonusRules
{
    public sealed record class GetAllBonusRulesQuery() : IRequest<Result<List<BonusRuleDto>>>;
}
