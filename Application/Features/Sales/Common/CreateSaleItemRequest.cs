namespace Application.Features.Sales.Common
{
    public sealed record CreateSaleItemRequest(
        Guid ProductVariantId,
        int Quantity);
}
