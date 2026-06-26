using Application.Common.Results;
using MediatR;

namespace Application.Features.BonusRules.Commands.ActivateBonusRule
{
    public sealed record class ActivateBonusRuleCommand(Guid Id) : IRequest<Result>;
}
