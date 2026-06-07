using Application.Common.Results;
using Application.Features.Sales.DTOs;
using Application.Interfaces.Repositories.Read.Common;
using MediatR;

namespace Application.Features.Sales.Queries.GetTopSellingProducts
{
    public sealed class GetTopSellingProductQueryHandler : IRequestHandler<GetTopSellingProductsQuery, Result<List<TopSellingProductDto>>>
    {
        private readonly ISaleReadRepository _saleReadRepository;

        public GetTopSellingProductQueryHandler(ISaleReadRepository saleReadRepository)
        {
            _saleReadRepository = saleReadRepository;
        }

        public async Task<Result<List<TopSellingProductDto>>> Handle(GetTopSellingProductsQuery request, CancellationToken cancellationToken)
        {
            var result = await _saleReadRepository.GetTopSellingProductAsync(request.count);
            if (result == null)
                return Result<List<TopSellingProductDto>>.Failure("Top seller product not found");

            return Result<List<TopSellingProductDto>>.Success(result);
        }
    }
}
