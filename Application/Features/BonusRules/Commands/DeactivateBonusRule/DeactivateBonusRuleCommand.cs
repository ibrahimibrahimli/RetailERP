using Application.Common.Results;
using MediatR;

namespace Application.Features.BonusRules.Commands.DeactivateBonusRule
{
    public sealed record class DeactivateBonusRuleCommand (Guid Id) : IRequest<Result>;
}
