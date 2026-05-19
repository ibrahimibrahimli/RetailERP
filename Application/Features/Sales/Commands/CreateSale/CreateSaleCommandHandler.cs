using Application.Common.Results;
using Application.Interfaces.Repositories.Read.Common;
using Application.Interfaces.Repositories.Write.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Sales.Commands.CreateSale
{
    public sealed class CreateSaleCommandHandler : IRequestHandler<CreateSaleCommand, Result<Guid>>
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IBranchInventoryReadRepository _branchInventoryReadRepository;
        private readonly IBranchInventoryWriteRepository _branchInventoryWriteRepository;
        private readonly ISaleWriteRepository _saleWriteRepository;
        private readonly IInventoryTransactionWriteRepository _inventoryTransactionWriteRepository;
        public CreateSaleCommandHandler(
            IProductReadRepository productReadRepository,
            IBranchInventoryReadRepository branchInventoryReadRepository,
            IBranchInventoryWriteRepository branchInventoryWriteRepository,
            ISaleWriteRepository saleWriteRepository,
            IInventoryTransactionWriteRepository inventoryTransactionWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _branchInventoryReadRepository = branchInventoryReadRepository;
            _branchInventoryWriteRepository = branchInventoryWriteRepository;
            _saleWriteRepository = saleWriteRepository;
            _inventoryTransactionWriteRepository = inventoryTransactionWriteRepository;
        }

        public async Task<Result<Guid>> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
        {
            string invoiceNumber = $"Sale-{Guid.NewGuid().ToString()[..8]}";
            var sale = Sale.Create(request.BranchId, invoiceNumber, request.PaymentMethod);

            foreach(var item in request.Items )
            {
                var product = await _productReadRepository.GetByIdAsync(item.ProductId);
                if (product is null)
                    return Result<Guid>.Failure("Product not found");

                var inventory = await _branchInventoryReadRepository.GetByProductAndBranchAsync(item.ProductId, request.BranchId);
                if (inventory is null)
                    return Result<Guid>.Failure("Inventory not fount");

                InventoryTransaction transaction = inventory.SellProduct(item.Quantity, invoiceNumber);

                await _inventoryTransactionWriteRepository.AddAsync(transaction);

                _branchInventoryWriteRepository.Update(inventory);

                sale.AddItem(product.Id,
                    product.Name,
                    product.Price,
                    item.Quantity);
            }

            await _saleWriteRepository.AddAsync(sale);
            await _saleWriteRepository.SaveChangesAsync();

            return Result<Guid>.Success(sale.Id);
        }
    }
}
