using Application.Features.Positions.Command.CreatePosition;
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

        [HttpPost]
        public async Task<IActionResult> Create(CreatePositionCommand command)
        {
            var result = await _mediator.Send(command);
            return HandleResult(result);
        }
    }
}
