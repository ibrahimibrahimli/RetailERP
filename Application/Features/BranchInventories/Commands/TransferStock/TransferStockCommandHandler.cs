using Application.Common.Results;
using Application.Interfaces.Repositories.Read.Common;
using Application.Interfaces.Repositories.Write.Common;
using MediatR;

namespace Application.Features.BranchInventories.Commands.TransferStock
{
    public class TransferStockCommandHandler : IRequestHandler<TransferStockCommand, Result>
    {
        private readonly IBranchInventoryWriteRepository _branchInventoryWriteRepository;
        private readonly IBranchInventoryReadRepository _branchInventoryReadRepository; 
        private readonly IInventoryTransactionWriteRepository _inventoryTransactionWriteRepository;

        public TransferStockCommandHandler(IBranchInventoryWriteRepository branchInventoryWriteRepository, IBranchInventoryReadRepository branchInventoryReadRepository, IInventoryTransactionWriteRepository inventoryTransactionWriteRepository)
        {
            _branchInventoryWriteRepository = branchInventoryWriteRepository;
            _branchInventoryReadRepository = branchInventoryReadRepository;
            _inventoryTransactionWriteRepository = inventoryTransactionWriteRepository;
        }

        public async Task<Result> Handle(TransferStockCommand request, CancellationToken cancellationToken)
        {
            var sourceInventory = await _branchInventoryReadRepository.GetByProductAndBranchAsync(request.ProductVariantId, request.FromBranchId);
            if (sourceInventory == null)
                return Result.Failure("Source inventory is not found");

            var destinationInventory = await _branchInventoryReadRepository.GetByProductAndBranchAsync(request.ProductVariantId, request.ToBranchId);
            if (destinationInventory == null)
                return Result.Failure("Destination inventory is not found");

            try
            {
                string transferCode = $"TRF-{Guid.NewGuid().ToString()[..8]}";
                var outTransaction = sourceInventory.TransferOut(request.Quantity, transferCode);

                var inTransaction = destinationInventory.TransferIn(request.Quantity, transferCode);

                _branchInventoryWriteRepository.Attach(sourceInventory);
                _branchInventoryWriteRepository.Attach(destinationInventory);


                await _inventoryTransactionWriteRepository.AddAsync(outTransaction);
                await _inventoryTransactionWriteRepository.AddAsync(inTransaction);
                await _branchInventoryWriteRepository.SaveChangesAsync();

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }
    }
}
