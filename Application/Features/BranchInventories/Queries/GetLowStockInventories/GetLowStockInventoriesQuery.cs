using Application.Common.Results;
using Application.Features.BranchInventories.DTOs;
using MediatR;

namespace Application.Features.BranchInventories.Queries.GetLowStockInventories
{
    public sealed record GetLowStockInventoriesQuery() : IRequest<Result<List<LowStockDto>>>;
}
