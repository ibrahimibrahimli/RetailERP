using Domain.Enums;

namespace Application.Features.Sales.DTOs
{
    public sealed record SaleDetailDto(
        Guid SaleId,
        string InvoiceNumber,
        decimal TotalAmount,
        PaymentMethod PaymentMethod,
        DateTime SaleDate,
        List<SaleItemDto> Items);
    
}
