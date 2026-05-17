using Application.Common.Results;
using Application.Interfaces.Repositories.Read.Common;
using Application.Interfaces.Repositories.Write.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.BranchInventories.Commands.AddStock
{
    public class AddStockCommandHandler : IRequestHandler<AddStockCommand, Result>
    {
        private readonly IBranchInventoryWriteRepository _inventoryWriteRepository;
        private readonly IBranchInventoryReadRepository _inventoryReadRepository;
        private readonly IInventoryTransactionWriteRepository _inventoryTransactionWriteRepository;

        public AddStockCommandHandler(IBranchInventoryWriteRepository ınventoryWriteRepository, IBranchInventoryReadRepository inventoryReadRepository, IInventoryTransactionWriteRepository inventoryTransactionWriteRepository)
        {
            _inventoryWriteRepository = ınventoryWriteRepository;
            _inventoryReadRepository = inventoryReadRepository;
            _inventoryTransactionWriteRepository = inventoryTransactionWriteRepository;
        }

        public async Task<Result> Handle(AddStockCommand request, CancellationToken cancellationToken)
        {
            var inventory = await _inventoryReadRepository.GetByProductAndBranchAsync(request.ProductId, request.BranchId);
            if (inventory is null)
                return Result.Failure("Inventory record not found");

            InventoryTransaction transaction = inventory.AddStock(request.Quantity);

            await _inventoryTransactionWriteRepository.AddAsync(transaction);

            await _inventoryWriteRepository.SaveChangesAsync();

            return Result.Success();
        }
    }
}
