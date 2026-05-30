using Application.Common.Results;
using Application.Features.BranchInventories.DTOs;
using Application.Interfaces.Repositories.Read.Common;
using MediatR;

namespace Application.Features.BranchInventories.Queries.GetProductVariantAvailability
{
    public sealed class GetProductVariantAvailabilityQueryHandler : IRequestHandler<GetProductVariantAvailabilityQuery,
                                                                                    Result<List<VariantAvailabilityDto>>>
    {
        private readonly IBranchInventoryReadRepository _branchInventoryReadRepository;

        public GetProductVariantAvailabilityQueryHandler(IBranchInventoryReadRepository branchInventoryReadRepository)
        {
            _branchInventoryReadRepository = branchInventoryReadRepository;
        }

        public async Task<Result<List<VariantAvailabilityDto>>> Handle(GetProductVariantAvailabilityQuery request, CancellationToken cancellationToken)
        {
            var inventories = await _branchInventoryReadRepository.GetProductVariantAsync(request.ProductVariantId);
            if (inventories == null)
                return Result<List<VariantAvailabilityDto>>.Failure("Inventories not found");

            List<VariantAvailabilityDto> response = inventories.Select(x => new VariantAvailabilityDto(
                x.BranchId,
                x.Branch.Name,
                x.Quantity,
                x.IsSelling)).ToList();

            return Result<List<VariantAvailabilityDto>>.Success(response);
        }
    }
}
