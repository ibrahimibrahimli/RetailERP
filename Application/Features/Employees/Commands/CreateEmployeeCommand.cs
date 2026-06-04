using Application.Common.Results;
using MediatR;

namespace Application.Features.Employees.Commands
{
    public sealed record CreateEmployeeCommand(
        Guid BranchId,
        string FirstName,
        string LastName,
        string EmployeeCode) : IRequest<Result<Guid>>;
}
