using Application.Common.Results;
using Application.Features.Sales.DTOs;
using MediatR;

namespace Application.Features.Sales.Queries.GetSalesByDateRange
{
    public sealed record GetSalesByDateRangeQuery(
        DateOnly StartDate,
        DateOnly EndDate) : IRequest<Result<List<SaleListDto>>>;
}
