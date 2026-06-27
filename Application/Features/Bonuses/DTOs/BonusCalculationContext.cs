namespace Application.Features.Bonuses.DTOs
{
    public sealed class BonusCalculationContext(
        Guid EmployeeId,
        Guid PositionId,
        decimal PersonalSales,
        DateOnly CalculationDate);
}
