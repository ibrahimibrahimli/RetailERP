using Application.Common.Results;
using Application.Features.Sales.DTOs;
using MediatR;

namespace Application.Features.Sales.Queries.GetSalesByEmployeeQuery
{
    public sealed record GetSalesByEmployeeQuery(
        Guid EmployeeId) : IRequest<Result<List<EmployeeSalesDto>>>;
}
