namespace Application.Features.BranchInventories.DTOs
{
    public sealed record LowStockDto(
        Guid ProductVariantId,
        string ProductName,
        Guid BranchId,
        string BranchName,
        int Quantity,
        int MinimumStockLevel);
}
