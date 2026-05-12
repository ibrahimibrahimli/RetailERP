using Application.Common.Results;
using MediatR;

namespace Application.Features.BranchInventories.Commands.TransferStock
{
    public sealed record TransferStockCommand(
        Guid ProductId,
        Guid FromBranchId,
        Guid ToBranchId,
        int Quantity) : IRequest<Result>;
}
