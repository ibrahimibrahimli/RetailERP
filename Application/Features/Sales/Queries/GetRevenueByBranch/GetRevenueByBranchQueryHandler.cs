using Application.Common.Results;
using Application.Features.Sales.DTOs;
using Application.Interfaces.Repositories.Read.Common;
using MediatR;

namespace Application.Features.Sales.Queries.GetRevenueByBranch
{
    public sealed class GetRevenueByBranchQueryHandler : IRequestHandler<GetRevenueByBranchQuery, Result<List<BranchRevenueDto>>>
    {
        private readonly ISaleReadRepository _saleReadRepository;

        public GetRevenueByBranchQueryHandler(ISaleReadRepository saleReadRepository)
        {
            _saleReadRepository = saleReadRepository;
        }

        public async Task<Result<List<BranchRevenueDto>>> Handle(GetRevenueByBranchQuery request, CancellationToken cancellationToken)
        {
            var sales = await _saleReadRepository.GetRevenueByBranchAsync(request.Count);
            if (sales == null)
                return Result<List<BranchRevenueDto>>.Failure("Sales not found");

            var response = sales
                .GroupBy(x => new
                {
                    x.BranchId,
                    x.Branch.Name
                })
                .Select(x => new BranchRevenueDto(
                    x.Key.BranchId,
                    x.Key.Name,
                    x.Count(),
                    x.Sum(x => x.TotalAmount)))
                .OrderByDescending(x => x.Revenue)
                .Take(request.Count)
                .ToList();

            return Result<List<BranchRevenueDto>>.Success(response);
        }
    }
}
