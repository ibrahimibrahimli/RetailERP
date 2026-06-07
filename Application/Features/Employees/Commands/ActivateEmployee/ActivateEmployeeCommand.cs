using Application.Common.Results;
using MediatR;

namespace Application.Features.Employees.Commands.ActivateEmployee
{
    public sealed record ActivateEmployeeCommand(Guid Id) : IRequest<Result>;
}
