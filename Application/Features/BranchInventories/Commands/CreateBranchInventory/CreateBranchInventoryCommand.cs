using Application.Common.Results;
using MediatR;

namespace Application.Features.BranchInventories.Commands.CreateBranchInventory
{
    public sealed record CreateBranchInventoryCommand(
        Guid ProductId,
        Guid BranchId,
        int InitialQuantity,
        int MinimumStockLevel) : IRequest<Result<Guid>>;
}
