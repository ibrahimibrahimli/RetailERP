using Application.Common.Results;
using Application.Interfaces.Repositories.Read.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProductVariants.Commands.CreateProductVariant
{
    public sealed class CreateProductVariantCommandHandler : IRequestHandler<CreateProductVariantCommand, Result<Guid>>
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductVariantWriteRepository _productVariantWriteRepository;
        public CreateProductVariantCommandHandler(IProductReadRepository productReadRepository, IProductVariantWriteRepository productVariantWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productVariantWriteRepository = productVariantWriteRepository;
        }

        public async Task<Result<Guid>> Handle(CreateProductVariantCommand request, CancellationToken cancellationToken)
        {
            var product = await _productReadRepository.GetByIdAsync(request.ProductId);
            if (product == null)
                return Result<Guid>.Failure("Product not found. To add product variants, first add the product");

            ProductVariant variant = ProductVariant.Create(request.ProductId,
                                                           request.Color,
                                                           request.Size,
                                                           request.SKU,
                                                           request.Barcode);

            await _productVariantWriteRepository.AddAsync(variant);
            await _productVariantWriteRepository.SaveChangesAsync();

            return Result<Guid>.Success(variant.Id);
        }
    }
}
