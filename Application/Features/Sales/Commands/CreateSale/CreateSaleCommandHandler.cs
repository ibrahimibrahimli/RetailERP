using Application.Common.Results;
using Application.Interfaces.Repositories.Read.Common;
using Application.Interfaces.Repositories.Write.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Sales.Commands.CreateSale
{
    public sealed class CreateSaleCommandHandler : IRequestHandler<CreateSaleCommand, Result<Guid>>
    {
        private readonly IProductVariantReadRepository _productVariantReadRepository;
        private readonly IBranchInventoryReadRepository _branchInventoryReadRepository;
        private readonly IBranchInventoryWriteRepository _branchInventoryWriteRepository;
        private readonly ISaleWriteRepository _saleWriteRepository;
        private readonly IInventoryTransactionWriteRepository _inventoryTransactionWriteRepository;
        public CreateSaleCommandHandler(
            IBranchInventoryReadRepository branchInventoryReadRepository,
            IBranchInventoryWriteRepository branchInventoryWriteRepository,
            ISaleWriteRepository saleWriteRepository,
            IInventoryTransactionWriteRepository inventoryTransactionWriteRepository,
            IProductVariantReadRepository productVariantReadRepository)
        {
            _branchInventoryReadRepository = branchInventoryReadRepository;
            _branchInventoryWriteRepository = branchInventoryWriteRepository;
            _saleWriteRepository = saleWriteRepository;
            _inventoryTransactionWriteRepository = inventoryTransactionWriteRepository;
            _productVariantReadRepository = productVariantReadRepository;
        }

        public async Task<Result<Guid>> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
        {
            string invoiceNumber = $"Sale-{Guid.NewGuid().ToString()[..8]}";
            var sale = Sale.Create(request.BranchId, invoiceNumber, request.PaymentMethod);

            foreach(var item in request.Items )
            {
                var variant = await _productVariantReadRepository.GetByIdAsync(item.ProductVariantId);
                if (variant is null)
                    return Result<Guid>.Failure("Product not found");

                var inventory = await _branchInventoryReadRepository.GetByProductAndBranchAsync(item.ProductVariantId, request.BranchId);
                if (inventory is null)
                    return Result<Guid>.Failure("Inventory not fount");

                InventoryTransaction transaction = inventory.SellProduct(item.Quantity, invoiceNumber);

                await _inventoryTransactionWriteRepository.AddAsync(transaction);

                _branchInventoryWriteRepository.Update(inventory);

                sale.AddItem(variant.Id,
                    variant.Product.Name,
                    variant.Color,
                    variant.Size,
                    variant.SKU,
                    variant.Product.Price,
                    item.Quantity);
            }

            await _saleWriteRepository.AddAsync(sale);
            await _saleWriteRepository.SaveChangesAsync();

            return Result<Guid>.Success(sale.Id);
        }
    }
}
