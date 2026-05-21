using Application.Common.Results;
using Application.Features.Sales.DTOs;
using Application.Interfaces.Repositories.Read.Common;
using MediatR;

namespace Application.Features.Sales.Queries.GetAllSales
{
    public sealed class GetAllSalesQueryHandler : IRequestHandler<GetAllSalesQuery, Result<List<SaleListDto>>>
    {
        private readonly ISaleReadRepository _saleReadRepository;

        public GetAllSalesQueryHandler(ISaleReadRepository saleReadRepository)
        {
            _saleReadRepository = saleReadRepository;
        }

        public async Task<Result<List<SaleListDto>>> Handle(GetAllSalesQuery request, CancellationToken cancellationToken)
        {
            var sales = await _saleReadRepository.GetAllSalesAsync();
            if (sales is null)
                return Result<List<SaleListDto>>.Failure("Sales no t found");

            List<SaleListDto> response = sales.Select(x => 
                                                      new SaleListDto(
                                                          x.Id, 
                                                          x.InvoiceNumber,
                                                          x.TotalAmount,
                                                          x.PaymentMethod,
                                                          x.SaleDate)).ToList();
            return Result<List<SaleListDto>>.Success(response);
        }
    }
}
