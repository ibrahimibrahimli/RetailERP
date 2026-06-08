using Application.Common.Results;
using Application.Features.Sales.DTOs;
using MediatR;

namespace Application.Features.Sales.Queries.GetSalesSummaryByDateRange
{
    public sealed record GetSalesSummaryByDateRangeQuery(
        DateOnly StartDate,
        DateOnly EndDate) : IRequest<Result<SaleSummaryDto>>;
}
