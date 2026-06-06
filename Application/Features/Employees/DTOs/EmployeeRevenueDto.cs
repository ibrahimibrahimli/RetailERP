namespace Application.Features.Employees.DTOs
{
    public sealed record EmployeeRevenueDto(
        Guid EmployeeId,
        int SalesCount,
        decimal TotalRevenue);  
}
