using Application.Common.Results;
using Application.Features.Sales.DTOs;
using MediatR;

namespace Application.Features.Sales.Queries.GetSaleById
{
    public sealed record GetSaleByIdQuery(Guid SaleId) : IRequest<Result<SaleDetailDto>>;
} 
