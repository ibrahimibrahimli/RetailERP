using Application.Common.Results;
using Application.Features.Sales.DTOs;
using MediatR;

namespace Application.Features.Sales.Queries.GetRevenueByBranch
{
    public sealed record GetRevenueByBranchQuery(int Count) : IRequest<Result<List<BranchRevenueDto>>>;
}
