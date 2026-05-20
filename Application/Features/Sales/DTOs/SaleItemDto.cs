namespace Application.Features.Sales.DTOs
{
    public sealed record SaleItemDto(
        Guid ProductId,
        string ProductName,
        decimal UnitPrice,
        int Quantity,
        decimal TotalPrice);
}
