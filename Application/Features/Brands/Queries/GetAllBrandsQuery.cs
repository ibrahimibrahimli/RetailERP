using Application.Common.Results;
using Application.Features.Brands.Dtos;
using MediatR;

namespace Application.Features.Brands.Queries
{
    public sealed record GetAllBrandsQuery : IRequest<Result<List<BrandDto>>>;
}
