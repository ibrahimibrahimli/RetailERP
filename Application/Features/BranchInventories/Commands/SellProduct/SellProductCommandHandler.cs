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

        public SellProductCommandHandler(IBranchInventoryWriteRepository inventoryWriteRepository, IBranchInventoryReadRepository inventoryReadRepository)
        {
            _inventoryWriteRepository = inventoryWriteRepository;
            _inventoryReadRepository = inventoryReadRepository;
        }

        public async Task<Result> Handle(SellProductCommand request, CancellationToken cancellationToken)
        {
            var inventory = await _inventoryReadRepository.GetByProductAndBranchAsync(request.ProductId, request.BranchId);
            if (inventory == null)
                return Result.Failure("Inventory is not found");

            try
            {
                inventory.SellProduct(request.Quantity);
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
