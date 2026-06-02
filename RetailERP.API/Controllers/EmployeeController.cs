using Application.Features.Employees.Commands;
using Application.Features.Sales.Queries.GetSalesByEmployeeQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RetailERP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseController
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeCommand command)
        {
            var result = await _mediator.Send(command);
            return HandleResult(result);
        }

        [HttpGet("{id:guid}/sales")]
        public async Task<IActionResult> GetSales(Guid id)
        {
            var result = await _mediator.Send(new GetSalesByEmployeeQuery(id));
            return HandleResult(result);
        }
    }
}
