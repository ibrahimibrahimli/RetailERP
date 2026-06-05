using Application.Features.Employees.Commands.ActivateEmployee;
using Application.Features.Employees.Commands.CreateEmployee;
using Application.Features.Employees.Commands.DeactivateEmployee;
using Application.Features.Employees.Queries.GetAllEmployees;
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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllEmployeesQuery());
            return HandleResult(result);
        }

        [HttpPatch("{id:guid}/deactivate")]
        public async Task<IActionResult> Deactivate(Guid id)
        {
            var result = await _mediator.Send( new DeactivateEmployeeCommand(id));
            return HandleResult(result);
        }

        [HttpPatch("{id:guid}/activate")]
        public async Task<IActionResult> Activate(Guid id)
        {
            var result = await _mediator.Send(new ActivateEmployeeCommand(id));
            return HandleResult(result);
        }
    }
}
