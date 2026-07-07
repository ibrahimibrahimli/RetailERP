namespace Application.Features.Bonuses.DTOs
{
    public sealed record class EmployeeSalesRankingDto(
        Guid EmployeeId,
        decimal PersonalSales);
}