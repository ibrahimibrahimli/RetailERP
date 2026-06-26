using Application.Features.BonusRules.Commands.ActivateBonusRule;
using Application.Features.BonusRules.Commands.DeactivateBonusRule;
using Application.Features.BonusRules.Queries.GetAllBonusRules;
using Application.Features.BonusRules.Queries.GetBonusRuleById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RetailERP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BonusRuleController : BaseController
    {
        private readonly IMediator _mediator;

        public BonusRuleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBonusRules([FromQuery] GetAllBonusRulesQuery query)
        {
            var result = await _mediator.Send(query);
            return HandleResult(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            var result = await _mediator.Send(new GetBonusRuleByIdQuery(Id));
            return HandleResult(result);
        }

        [HttpPatch("{id:guid/}activate")]
        public async Task<IActionResult> Activate(Guid Id)
        {
            var result = await _mediator.Send(new ActivateBonusRuleCommand (Id));
            return HandleResult(result);
        }

        [HttpPatch("{id/guid}/deActivate")]
        public async Task<IActionResult> DeActivate(Guid Id)
        {
            var result = await _mediator.Send(new DeactivateBonusRuleCommand (Id));
            return HandleResult(result);
        }
    }
}
