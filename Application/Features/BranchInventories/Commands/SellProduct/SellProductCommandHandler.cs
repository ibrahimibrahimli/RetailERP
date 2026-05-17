using Application.Common.Results;
using Application.Interfaces.Repositories.Read.Common;
using Application.Interfaces.Repositories.Write.Common;
using MediatR;

namespace Application.Features.BranchInventories.Commands.SellProduct
{
    public class SellProductCommandHandler : IRequestHandler<SellProductCommand, Result>
    {
        private readonly IBranchInventoryWriteRepository _inventoryWriteRepository;
        private readonly IBranchInventoryReadRepository _inventoryReadRepository;
        private readonly IInventoryTransactionWriteRepository _inventoryTransactionWriteRepository;

        public SellProductCommandHandler(IBranchInventoryWriteRepository inventoryWriteRepository, IBranchInventoryReadRepository inventoryReadRepository, IInventoryTransactionWriteRepository inventoryTransactionWriteRepository)
        {
            _inventoryWriteRepository = inventoryWriteRepository;
            _inventoryReadRepository = inventoryReadRepository;
            _inventoryTransactionWriteRepository = inventoryTransactionWriteRepository;
        }

        public async Task<Result> Handle(SellProductCommand request, CancellationToken cancellationToken)
        {
            var inventory = await _inventoryReadRepository.GetByProductAndBranchAsync(request.ProductId, request.BranchId);
            if (inventory == null)
                return Result.Failure("Inventory is not found");

            try
            {
                var transaction = inventory.SellProduct(request.Quantity);
                await _inventoryTransactionWriteRepository.AddAsync(transaction);
            }
            catch (Exception ex)
            {

                return Result.Failure(ex.Message);
            }

            await _inventoryWriteRepository.SaveChangesAsync();

            return Result.Success();
        }
    }
}
