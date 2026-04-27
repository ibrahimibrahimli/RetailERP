using Application.Features.SubCompanies.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RetailERP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCompanyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SubCompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]

        public async Task<IActionResult> Create(CreateSubCompanyCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok(result);  
        }
    }
}
