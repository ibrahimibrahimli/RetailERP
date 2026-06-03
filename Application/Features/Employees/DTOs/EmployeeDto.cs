namespace Application.Features.Employees.DTOs
{
    public sealed record EmployeeDto(
        Guid Id,
        string EmployeeCode,
        string FirstName,
        string LastName,
        bool IsActive,
        Guid BranchId,
        string BranchName);
}
