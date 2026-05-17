using Application.Common.Results;
using Application.Features.InventoryTransactions.DTOs;
using MediatR;

namespace Application.Features.InventoryTransactions.Queries.GetInventoryTransactions
{
    public sealed record GetInventoryTransactionsQuery(Guid BranchInventoryId) : IRequest<Result<List<InventoryTransactionDto>>>;
}