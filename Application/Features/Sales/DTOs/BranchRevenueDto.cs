namespace Application.Features.Sales.DTOs
{
    public sealed record BranchRevenueDto(
        Guid BranchId,
        string BranchName,
        int SalesCount,
        decimal Revenue);
}
