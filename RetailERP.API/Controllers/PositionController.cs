using Application.Features.Positions.Command.ActivatePosition;
using Application.Features.Positions.Command.CreatePosition;
using Application.Features.Positions.Command.DeactivatePosition;
using Application.Features.Positions.Queries.GetAllPositions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RetailERP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : BaseController
    {
        private readonly IMediator _mediator;

        public PositionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllPositionsQuery());
            return HandleResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePositionCommand command)
        {
            var result = await _mediator.Send(command);
            return HandleResult(result);
        }

        [HttpPut("{id:guid}/activate")]
        public async Task<IActionResult> Activate(ActivatePositionCommand command)
        {
            var result = await _mediator.Send(command);
            return HandleResult(result);
        }

        [HttpPut("{id:guid}/deactivate")]
        public async Task<IActionResult> Deactivate(DeactivatePositionCommand command)
        {
            var result = await _mediator.Send(command); 
            return HandleResult(result);
        }
    }
}
