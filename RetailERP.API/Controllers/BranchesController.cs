using Application.Features.Branches.Commands.CreateBranch;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RetailERP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController : BaseController
    {
        private readonly IMediator _mediator;

        public BranchesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBranchCommand command)
        {
            var result = await _mediator.Send(command);
            return HandleResult(result);
        }
    }
}
