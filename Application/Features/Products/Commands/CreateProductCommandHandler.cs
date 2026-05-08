using Application.Common.Results;
using Application.Interfaces.Repositories.Read.Common;
using Application.Interfaces.Repositories.Write.Common;
using MediatR;
using RetailERP.Domain.Entities;

namespace Application.Features.Products.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Result<Guid>>
    {
        private readonly IProductReadRepository _readRepository;
        private readonly IProductWriteRepository _writeRepository;
        public CreateProductCommandHandler(IProductReadRepository readRepository, IProductWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<Result<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            bool isExistsBarcode = await _readRepository.ExistBarcodeAsync(request.Barcode);
            if (isExistsBarcode)
                return Result<Guid>.Failure("Barcode already exists");

            Product product = Product.Create(
                request.Name,
                request.Description,
                request.Price,
                request.Barcode,
                request.BrandId);

            await _writeRepository.AddAsync(product);
            await _writeRepository.SaveChangesAsync();

            return Result<Guid>.Success(product.Id);  
        }
    }
}
