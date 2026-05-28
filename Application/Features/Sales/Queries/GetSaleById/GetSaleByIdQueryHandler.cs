using Application.Common.Results;
using Application.Features.Sales.DTOs;
using Application.Interfaces.Repositories.Read.Common;
using MediatR;

namespace Application.Features.Sales.Queries.GetSaleById
{
    public sealed class GetSaleByIdQueryHandler : IRequestHandler<GetSaleByIdQuery, Result<SaleDetailDto>>
    {
        private readonly ISaleReadRepository _saleReadRepository;

        public GetSaleByIdQueryHandler(ISaleReadRepository saleReadRepository)
        {
            _saleReadRepository = saleReadRepository;
        }

        public async Task<Result<SaleDetailDto>> Handle(GetSaleByIdQuery request, CancellationToken cancellationToken)
        {
            var sale = await _saleReadRepository.GetSaleDetailAsync(request.SaleId);
            if (sale is null)
                return Result<SaleDetailDto>.Failure("Sale not found");

            SaleDetailDto response = new(
                sale.Id,
                sale.InvoiceNumber,
                sale.TotalAmount,
                sale.PaymentMethod,
                sale.SaleDate,
                sale.Items.Select(x =>
                                  new SaleItemDto(
                                      x.ProductVariantId,
                                      x.ProductName,
                                      x.Color,
                                      x.Size,
                                      x.SKU,
                                      x.UnitPrice,
                                      x.Quantity,
                                      x.TotalPrice)).ToList());

            return Result<SaleDetailDto>.Success(response);
        }
    }
}
