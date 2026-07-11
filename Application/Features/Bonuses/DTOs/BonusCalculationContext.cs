namespace Application.Features.Bonuses.DTOs
{
    public sealed record BonusCalculationContext(
     Guid EmployeeId,
     Guid PositionId,
     decimal PersonalSales,
     decimal StoreSales,
     DateOnly CalculationDate,
     IReadOnlyList<EmployeeSalesRankingDto> EmployeeRankings);
}
