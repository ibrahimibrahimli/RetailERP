using Application.Features.InventoryTransactions.Queries.GetInventoryTransactions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RetailERP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryTransactionsController : BaseController
    {
        private readonly IMediator _mediator;

        public InventoryTransactionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{branchInventoryId}")]
        public async Task<IActionResult> GetTransactions(Guid branchInventoryId)
        {
            var result = await _mediator.Send(new GetInventoryTransactionsQuery(branchInventoryId));
            return HandleResult(result);
        }
    }
}
