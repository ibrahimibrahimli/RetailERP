using Application.Common.Results;
using Application.Features.Employees.DTOs;
using MediatR;

namespace Application.Features.Employees.Queries.GetEmployeeRevenue
{
    public sealed record GetEmployeeRevenueQuery(Guid EmployeeId) : IRequest<Result<EmployeeRevenueDto>>;
}
