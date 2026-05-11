using Application.Features.BranchInventories.Commands.AddStock;
using Application.Features.BranchInventories.Commands.CreateBranchInventory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RetailERP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchInventoryController : BaseController
    {
        private readonly IMediator _mediator;

        public BranchInventoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add-stock")]
        public async Task<IActionResult> AddStock(AddStockCommand command)
        {
            var result = await _mediator.Send(command);
             return HandleResult(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateBranchInventoryCommand command)
        {
            var result = await _mediator.Send(command);
            return HandleResult(result);
        }
    }
}
