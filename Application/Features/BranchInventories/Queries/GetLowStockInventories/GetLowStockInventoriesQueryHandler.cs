using Application.Common.Results;
using Application.Features.BranchInventories.DTOs;
using Application.Interfaces.Repositories.Read.Common;
using MediatR;

namespace Application.Features.BranchInventories.Queries.GetLowStockInventories
{
    public sealed class GetLowStockInventoriesQueryHandler : IRequestHandler<GetLowStockInventoriesQuery, Result<List<LowStockDto>>>
    {
        private readonly IBranchInventoryReadRepository _readRepository;

        public GetLowStockInventoriesQueryHandler(IBranchInventoryReadRepository readRepository )
        {
            _readRepository = readRepository;
        }

        public async Task<Result<List<LowStockDto>>> Handle(GetLowStockInventoriesQuery request, CancellationToken cancellationToken)
        {
            var inventories = await _readRepository.GetLowStockInventoriesAsync();
            if (inventories == null)
                return Result<List<LowStockDto>>.Failure("Not found low stock inventory");

            List<LowStockDto> response = inventories
                .Select(x => new LowStockDto(
                    x.ProductId,
                    x.Product.Name,
                    x.BranchId,
                    x.Branch.Name,
                    x.Quantity,
                    x.MinimumStockLevel))
                .ToList();

            return Result<List<LowStockDto>>.Success(response);
        }
    }
}
