namespace Application.Features.BranchInventories.DTOs
{
    public sealed record VariantAvailabilityDto(Guid BranchId, string BranchName, int quantity, bool IsSelling);
}
