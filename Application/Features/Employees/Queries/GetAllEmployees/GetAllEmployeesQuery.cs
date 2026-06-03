using Application.Common.Results;
using Application.Features.Employees.DTOs;
using MediatR;

namespace Application.Features.Employees.Queries.GetAllEmployees
{
    public sealed record GetAllEmployeesQuery(): IRequest<Result<List<EmployeeDto>>>;
}
