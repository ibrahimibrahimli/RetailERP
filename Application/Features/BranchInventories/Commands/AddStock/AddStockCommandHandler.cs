using Application.Common.Results;
using Application.Interfaces.Repositories.Read.Common;
using Application.Interfaces.Repositories.Write.Common;
using MediatR;

namespace Application.Features.BranchInventories.Commands.AddStock
{
    public class AddStockCommandHandler : IRequestHandler<AddStockCommand, Result>
    {
        private readonly IBranchInventoryWriteRepository _inventoryWriteRepository;
        private readonly IBranchInventoryReadRepository _inventoryReadRepository;

        public AddStockCommandHandler(IBranchInventoryWriteRepository ınventoryWriteRepository, IBranchInventoryReadRepository inventoryReadRepository)
        {
            _inventoryWriteRepository = ınventoryWriteRepository;
            _inventoryReadRepository = inventoryReadRepository;
        }

        public async Task<Result> Handle(AddStockCommand request, CancellationToken cancellationToken)
        {
            var inventory = await _inventoryReadRepository.GetByProductAndBranchAsync(request.ProductId, request.BranchId);
            if (inventory is null)
                return Result.Failure("Inventory record not found");

            inventory.AddStock(request.Quantity);

            await _inventoryWriteRepository.SaveChangesAsync();

            return Result.Success();
        }
    }
}
