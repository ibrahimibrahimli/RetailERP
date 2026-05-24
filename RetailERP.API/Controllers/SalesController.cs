using Application.Features.Sales.Commands.CreateSale;
using Application.Features.Sales.Queries.GetAllSales;
using Application.Features.Sales.Queries.GetSaleById;
using Application.Features.Sales.Queries.GetSalesByBranch;
using Application.Features.Sales.Queries.GetSalesByDateRange;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RetailERP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : BaseController
    {
        private readonly IMediator _mediator;

        public SalesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSaleCommand command)
        {
            var result = await _mediator.Send(command);
            return HandleResult(result);
        }

        [HttpGet("{saleId}")]
        public async Task<IActionResult> GetById(Guid saleId)
        {
            var result = await _mediator.Send(new GetSaleByIdQuery(saleId));
            return HandleResult(result);    
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllSalesQuery());
            return HandleResult(result);
        }

        [HttpGet("branch/{branchId}")]
        public async Task<IActionResult> GetByBranch(Guid branchId)
        {
            var result = await _mediator.Send(new GetSalesByBranchQuery(branchId));
            return HandleResult(result);
        }

        [HttpGet("date-range")]
        public async Task<IActionResult> GetByDateRange([FromQuery] DateOnly startDate, [FromQuery] DateOnly endDate)
        {
            var result = await _mediator.Send(new GetSalesByDateRangeQuery(startDate, endDate));
            return HandleResult(result);
        }
    }
}
