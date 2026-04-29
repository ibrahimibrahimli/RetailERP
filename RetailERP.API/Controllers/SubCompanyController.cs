using Application.Features.SubCompanies.Command;
using Application.Features.SubCompanies.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RetailERP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCompanyController : BaseController
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

            return HandleResult(result);  
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllSubCompaniesQuery());

            return HandleResult(result);
        }
    }
}
