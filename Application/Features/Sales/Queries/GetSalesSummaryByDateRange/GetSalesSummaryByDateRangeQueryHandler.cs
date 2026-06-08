using Application.Common.Results;
using Application.Features.Sales.DTOs;
using Application.Interfaces.Repositories.Read.Common;
using MediatR;

namespace Application.Features.Sales.Queries.GetSalesSummaryByDateRange
{
    public sealed class GetSalesSummaryByDateRangeQueryHandler : IRequestHandler<GetSalesSummaryByDateRangeQuery, Result<SaleSummaryDto>>
    {
        private readonly ISaleReadRepository _saleReadRepository;

        public GetSalesSummaryByDateRangeQueryHandler(ISaleReadRepository saleReadRepository)
        {
            _saleReadRepository = saleReadRepository;
        }

        public async Task<Result<SaleSummaryDto>> Handle(GetSalesSummaryByDateRangeQuery request, CancellationToken cancellationToken)
        {
            var start = request.StartDate.ToDateTime(TimeOnly.MinValue, DateTimeKind.Utc);
            var end = request.EndDate.ToDateTime(TimeOnly.MaxValue, DateTimeKind.Utc);

            var sales = await _saleReadRepository.GetByDateRangeAsync(start, end);

            SaleSummaryDto response = new(sales.Count, sales.Sum(x => x.TotalAmount));

            return Result<SaleSummaryDto>.Success(response);
        }
    }
}
