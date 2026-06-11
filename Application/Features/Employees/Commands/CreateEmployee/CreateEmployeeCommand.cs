using Application.Common.Results;
using MediatR;

namespace Application.Features.Employees.Commands.CreateEmployee
{
    public sealed record CreateEmployeeCommand(
        Guid BranchId,
        Guid PositionId,
        string FirstName,
        string LastName,
        string EmployeeCode) : IRequest<Result<Guid>>;
}
