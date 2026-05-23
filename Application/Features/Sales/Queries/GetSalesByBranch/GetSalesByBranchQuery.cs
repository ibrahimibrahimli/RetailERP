using Application.Common.Results;
using Application.Features.Sales.DTOs;
using MediatR;

namespace Application.Features.Sales.Queries.GetSalesByBranch
{
    public sealed record GetSalesByBranchQuery(
        Guid BranchId) : IRequest<Result<List<SaleListDto>>>;
}
