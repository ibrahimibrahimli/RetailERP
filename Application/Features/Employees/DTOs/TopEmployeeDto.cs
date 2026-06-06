namespace Application.Features.Employees.DTOs
{
    public sealed record TopEmployeeDto(
        Guid EmployeeId,
        string EmployeeCode,
        string FullName,
        int SalesCount,
        decimal Revenue);
}
