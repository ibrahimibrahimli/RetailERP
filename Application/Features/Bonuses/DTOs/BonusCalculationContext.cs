namespace Application.Features.Bonuses.DTOs
{
    public sealed record BonusCalculationContext(
     Guid EmployeeId,
     Guid PositionId,
     decimal PersonalSales,
     DateOnly CalculationDate,
     IReadOnlyList<EmployeeSalesRankingDto> EmployeeRankings);
}
