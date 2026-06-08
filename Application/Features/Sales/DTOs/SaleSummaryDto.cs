namespace Application.Features.Sales.DTOs
{
    public sealed record SaleSummaryDto(
        int SalesCount,
        decimal TotalRevenue);
}
