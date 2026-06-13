namespace Application.Features.Bonuses.DTOs
{
    public sealed record BonusEligibilityDto(
        Guid EmployeeId,
        bool IsEligible,
        string? Reason);
}
