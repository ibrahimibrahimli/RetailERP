using Domain.Enums;

namespace Application.Features.Sales.DTOs
{
    public sealed record SaleListDto(
        Guid SaleId,
        string InvoiceNumber,
        decimal TotalAmount,
        PaymentMethod PaymentMethod,
        DateTime SaleDate);
}
