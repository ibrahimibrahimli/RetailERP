namespace Application.Features.Sales.DTOs
{
    public sealed record TopSellingProductDto(
        Guid ProductVariantId,
        string ProductName,
        string Color,
        string Size,
        string SKU,
        int QuantitySold,
        decimal Revenue);
}
