using Application.Common.Results;
using MediatR;

namespace Application.Features.BranchInventories.Commands.AddStock
{
    public sealed record AddStockCommand(
        Guid ProductVariantId,
        Guid BranchId,
        int Quantity) : IRequest<Result>;
}
