using Application.Common.Results;
using Application.Features.BranchInventories.DTOs;
using MediatR;

namespace Application.Features.BranchInventories.Queries.GetProductVariantAvailability
{
    public sealed record GetProductVariantAvailabilityQuery(Guid ProductVariantId) : IRequest<Result<List<VariantAvailabilityDto>>>;
}
