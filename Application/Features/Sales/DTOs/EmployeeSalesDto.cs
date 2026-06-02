namespace Application.Features.Sales.DTOs
{
    public record EmployeeSalesDto(
        Guid SaleId,
        string InvoiceNumber,
        decimal TotalAmount,
        DateTime CreatetAt);
}
