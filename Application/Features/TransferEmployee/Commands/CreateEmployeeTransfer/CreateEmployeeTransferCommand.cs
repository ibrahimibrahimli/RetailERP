using Application.Common.Results;
using MediatR;

namespace Application.Features.TransferEmployee.Commands.CreateEmployeeTransfer
{
    public sealed record CreateEmployeeTransferCommand(
        Guid EmployeeId,
        Guid NewBranchId,
        Guid NewPositionId,
        DateOnly TransferDate,
        string? Reason) : IRequest<Result>;
}
