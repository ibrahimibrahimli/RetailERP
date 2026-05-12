using Application.Common.Results;
using MediatR;

namespace Application.Features.BranchInventories.Commands.SellProduct
{
    public sealed record SellProductCommand(
        Guid ProductId,
        Guid BranchId,
        int Quantity) : IRequest<Result>;
}
