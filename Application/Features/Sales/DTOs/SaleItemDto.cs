namespace Application.Features.Sales.DTOs
{
    public sealed record SaleItemDto(
        Guid ProductVariantId,
        string ProductName,
        decimal UnitPrice,
        int Quantity,
        decimal TotalPrice);
}
