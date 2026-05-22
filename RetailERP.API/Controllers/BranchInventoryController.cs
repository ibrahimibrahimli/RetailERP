using Application.Features.BranchInventories.Commands.AddStock;
using Application.Features.BranchInventories.Commands.CreateBranchInventory;
using Application.Features.BranchInventories.Commands.SellProduct;
using Application.Features.BranchInventories.Commands.TransferStock;
using Application.Features.BranchInventories.Queries.GetLowStockInventories;
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

        [HttpPost("sell-products")]
        ///Summary 
        ///Deprecated.
        /// Use Sales module instead.
        ///Summary
        public async Task<IActionResult> SellProduct(SellProductCommand command)
        {
            var result = await _mediator.Send(command);
            return HandleResult(result);
        }

        [HttpPost("transfer-stock")]
        public async Task<IActionResult> TransferStock(TransferStockCommand command)
        {
            var result = await _mediator.Send(command);
            return HandleResult(result);
        }

        [HttpGet("low-stock")]
        public async Task<IActionResult> GetLowStockInventories()
        {
            var result = await _mediator.Send(new GetLowStockInventoriesQuery());
            return HandleResult(result);
        }
    }
}
