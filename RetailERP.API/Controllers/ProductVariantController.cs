using Application.Features.ProductVariants.Commands.CreateProductVariant;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RetailERP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductVariantController : BaseController
    {
        private readonly IMediator _mediator;

        public ProductVariantController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductVariantCommand command)
        {
            var result = await _mediator.Send(command);
            return HandleResult(result);
        }
    }
}
