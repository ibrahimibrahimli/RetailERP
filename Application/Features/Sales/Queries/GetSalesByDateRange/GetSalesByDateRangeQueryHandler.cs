using Application.Common.Results;
using Application.Features.Sales.DTOs;
using Application.Interfaces.Repositories.Read.Common;
using MediatR;

namespace Application.Features.Sales.Queries.GetSalesByDateRange
{
    public sealed class GetSalesByDateRangeQueryHandler : IRequestHandler<GetSalesByDateRangeQuery, Result<List<SaleListDto>>>
    {
        private readonly ISaleReadRepository _saleReadRepository;

        public GetSalesByDateRangeQueryHandler(ISaleReadRepository saleReadRepository)
        {
            _saleReadRepository = saleReadRepository;
        }

        public async Task<Result<List<SaleListDto>>> Handle(GetSalesByDateRangeQuery request, CancellationToken cancellationToken)
        {
            var start = request.StartDate.ToDateTime(TimeOnly.MinValue, DateTimeKind.Utc);

            var end = request.EndDate.ToDateTime(TimeOnly.MaxValue, DateTimeKind.Utc);
            var sales = await _saleReadRepository.GetSalesByDateRangeAsync(start, end);
            if (sales is null)
                return Result<List<SaleListDto>>.Failure("Sales not found");

            var response = sales.Select(x => 
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
