using Application.Common.Results;
using Application.Features.Employees.DTOs;
using MediatR;

namespace Application.Features.Employees.Queries.GetTopEmployee
{
    public sealed record GetTopEmployeeQuery(int count = 10) : IRequest<Result<List<TopEmployeeDto>>>;
}
