using Application.Common.Results;
using Application.Features.Sales.DTOs;
using MediatR;

namespace Application.Features.Sales.Queries.GetTopSellingProducts
{
    public sealed record GetTopSellingProductsQuery(
        int count) : IRequest<Result<List<TopSellingProductDto>>>;
}
