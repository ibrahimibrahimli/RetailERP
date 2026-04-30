using Application.Common.Results;
using Application.Features.Brands.Dtos;
using Application.Interfaces.Repositories.Read.Common;
using MediatR;

namespace Application.Features.Brands.Queries
{
    public class GetAllBrandsQueryHandler : IRequestHandler<GetAllBrandsQuery, Result<List<BrandDto>>>
    {
        private readonly IBrandReadRepository _brandReadRepository;

        public GetAllBrandsQueryHandler(IBrandReadRepository brandReadRepository    )
        {
            _brandReadRepository = brandReadRepository;
        }

        public async Task<Result<List<BrandDto>>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
        {
            var brands = await _brandReadRepository.GetAllWithSubCompanyAsync();
            if (brands is null)
                return Result<List<BrandDto>>.Failure("Brands not found");

            var result = brands
                .Select(b => new BrandDto(
                   b.Id,
                   b.Name,
                   b.IsActive,
                   b.SubCompany.Name)).ToList();

            return Result<List<BrandDto>>.Success(result);
        }
    }
}
