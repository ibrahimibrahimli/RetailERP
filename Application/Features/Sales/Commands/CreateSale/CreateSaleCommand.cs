using Application.Common.Results;
using Application.Features.Sales.Common;
using Domain.Enums;
using MediatR;

namespace Application.Features.Sales.Commands.CreateSale
{
    public sealed record CreateSaleCommand(
        Guid BranchId,
        PaymentMethod PaymentMethod,
        List<CreateSaleItemRequest> Items) : IRequest<Result<Guid>>;
}
