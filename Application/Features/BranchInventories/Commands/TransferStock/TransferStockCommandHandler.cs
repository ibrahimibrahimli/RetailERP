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

        public TransferStockCommandHandler(IBranchInventoryWriteRepository branchInventoryWriteRepository, IBranchInventoryReadRepository branchInventoryReadRepository)
        {
            _branchInventoryWriteRepository = branchInventoryWriteRepository;
            _branchInventoryReadRepository = branchInventoryReadRepository;
        }

        public async Task<Result> Handle(TransferStockCommand request, CancellationToken cancellationToken)
        {
            var sourceInventory = await _branchInventoryReadRepository.GetByProductAndBranchAsync(request.ProductId, request.FromBranchId);
            if (sourceInventory == null)
                return Result.Failure("Source inventory is not found");

            var destinationInventory = await _branchInventoryReadRepository.GetByProductAndBranchAsync(request.ProductId, request.ToBranchId);
            if (destinationInventory == null)
                return Result.Failure("Destination inventory is not found");

            try
            {
                sourceInventory.DecreaseStock(request.Quantity);

                destinationInventory.IncreaseStock(request.Quantity);

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
