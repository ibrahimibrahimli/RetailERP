using Application.Features.Sales.Commands.CreateSale;
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
    }
}
