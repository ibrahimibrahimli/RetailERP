namespace Application.Features.Sales.DTOs
{
    public sealed record SaleItemDto(
        Guid ProductVariantId,
        string ProductName,
        string Color,
        string Size,
        string SKU,
        decimal UnitPrice,
        int Quantity,
        decimal TotalPrice);
}
