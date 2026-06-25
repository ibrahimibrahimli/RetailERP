using Application.Common.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BonusRules.Commands.ActivateBonusRule
{
    public sealed record class ActivateBonusRuleCommand(Guid Id) : IRequest<Result>;
}
