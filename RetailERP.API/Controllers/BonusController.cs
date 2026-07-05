using Application.Features.Bonuses.Queries.CalculateBonus;
using Application.Features.Bonuses.Queries.CheckBonusEligibility;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RetailERP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BonusController : BaseController
    {
        private readonly IMediator _mediator;

        public BonusController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("eligibility/{employeeId:guid}")]
        public async Task<IActionResult> CheckEligibility([FromQuery] CheckBonusEligibilityQuery query)
        {
            var result = await _mediator.Send(query);
            return HandleResult(result);
        }

        [HttpGet("calculate")]

        public async Task<IActionResult> Calculate([FromQuery] CalculateBonusQuery query)
        {
            var result = await _mediator.Send(query);
            return HandleResult(result);
        }
    }
}
