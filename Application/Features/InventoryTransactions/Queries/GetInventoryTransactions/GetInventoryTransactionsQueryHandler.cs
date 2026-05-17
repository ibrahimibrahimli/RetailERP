using Application.Common.Results;
using Application.Features.InventoryTransactions.DTOs;
using Application.Interfaces.Repositories.Read.Common;
using MediatR;

namespace Application.Features.InventoryTransactions.Queries.GetInventoryTransactions
{
    public sealed class GetInventoryTransactionsQueryHandler : IRequestHandler<GetInventoryTransactionsQuery, Result<List<InventoryTransactionDto>>>
    {
        private readonly IInventoryTransactionReadRepository _inventoryTransactionReadRepository;

        public GetInventoryTransactionsQueryHandler(IInventoryTransactionReadRepository inventoryTransactionReadRepository)
        {
            _inventoryTransactionReadRepository = inventoryTransactionReadRepository;
        }

        public async Task<Result<List<InventoryTransactionDto>>> Handle(GetInventoryTransactionsQuery request, CancellationToken cancellationToken)
        {
            var transactions = await _inventoryTransactionReadRepository.GetByBranchInventoryIdAsync(request.BranchInventoryId);
            if (transactions == null)
                return Result<List<InventoryTransactionDto>>.Failure("Transaction not found");

            List<InventoryTransactionDto> response = [.. transactions
                .Select(x => new InventoryTransactionDto(
                    x.Id,
                    x.Type,
                    x.Quantity,
                    x.Description,
                    x.CreatedAt))];

            return Result<List<InventoryTransactionDto>>.Success(response);
        }
    }
}
