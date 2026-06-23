using Application.Features.BonusRules.Queries.GetAllBonusRules;
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
    }
}
