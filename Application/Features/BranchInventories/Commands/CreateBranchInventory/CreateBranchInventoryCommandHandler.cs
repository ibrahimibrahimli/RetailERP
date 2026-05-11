using Application.Common.Results;
using Application.Interfaces.Repositories.Read.Common;
using Application.Interfaces.Repositories.Write.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.BranchInventories.Commands.CreateBranchInventory
{
    public class CreateBranchInventoryCommandHandler : IRequestHandler<CreateBranchInventoryCommand, Result<Guid>>
    {
        private readonly IBranchInventoryReadRepository _inventoryReadRepository;
        private readonly IBranchInventoryWriteRepository _inventoryWriteRepository;

        public CreateBranchInventoryCommandHandler(IBranchInventoryReadRepository inventoryReadRepository, IBranchInventoryWriteRepository inventoryWriteRepository)
        {
            _inventoryReadRepository = inventoryReadRepository;
            _inventoryWriteRepository = inventoryWriteRepository;
        }

        public async Task<Result<Guid>> Handle(CreateBranchInventoryCommand request, CancellationToken cancellationToken)
        {
            bool isExists = await _inventoryReadRepository.ExistsAsync(request.ProductId, request.BranchId);
            if (isExists)
                return Result<Guid>.Failure("Inventory already exists fro this branch");

            BranchInventory inventory = BranchInventory.Create(
                request.ProductId,
                request.BranchId,
                request.InitialQuantity,
                request.MinimumStockLevel);

            await _inventoryWriteRepository.AddAsync(inventory);
            await _inventoryWriteRepository.SaveChangesAsync();

            return Result<Guid>.Success(inventory.Id);
        }
    }
}
