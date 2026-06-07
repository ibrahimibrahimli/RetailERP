using Application.Common.Results;
using MediatR;

namespace Application.Features.Employees.Commands.DeactivateEmployee
{
    public sealed record DeactivateEmployeeCommand(
        Guid EmployeeId) : IRequest<Result>;
}
