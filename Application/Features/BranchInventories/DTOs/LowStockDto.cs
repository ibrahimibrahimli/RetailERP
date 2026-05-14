namespace Application.Features.BranchInventories.DTOs
{
    public sealed record LowStockDto(
        Guid ProductId,
        string ProductName,
        Guid BranchId,
        string BranchName,
        int Quantity,
        int MinimumStockLevel);
}
