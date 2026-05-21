using Application.Common.Results;
using Application.Features.Sales.DTOs;
using MediatR;

namespace Application.Features.Sales.Queries.GetAllSales
{
    public sealed record GetAllSalesQuery() : IRequest<Result<List<SaleListDto>>>;
}
