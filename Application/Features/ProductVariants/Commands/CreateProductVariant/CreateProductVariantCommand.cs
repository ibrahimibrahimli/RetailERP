using Application.Common.Results;
using MediatR;

namespace Application.Features.ProductVariants.Commands.CreateProductVariant
{
    public sealed record CreateProductVariantCommand(
        Guid ProductId,
        string Color, 
        string Size,
        string SKU,
        string Barcode) : IRequest<Result<Guid>>;
}
