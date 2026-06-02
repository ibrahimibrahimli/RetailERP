using Application.Common.Results;
using Application.Features.Sales.DTOs;
using Application.Interfaces.Repositories.Read.Common;
using MediatR;

namespace Application.Features.Sales.Queries.GetSalesByEmployeeQuery
{
    public sealed class GetSalesByEmployeeQueryHandler : IRequestHandler<GetSalesByEmployeeQuery, Result<List<EmployeeSalesDto>
    {
        private readonly ISaleReadRepository _saleReadRepository;

        public GetSalesByEmployeeQueryHandler(ISaleReadRepository saleReadRepository)
        {
            _saleReadRepository = saleReadRepository;
        }

        public async Task<Result<List<EmployeeSalesDto>>> Handle(GetSalesByEmployeeQuery request, CancellationToken cancellationToken)
        {
            var sales = await _saleReadRepository.GetByEmployeeAsync(request.EmployeeId);
            if (sales == null)
                return Result<List<EmployeeSalesDto>>.Failure("Sales not found");

            var response = sales.Select(x => 
                  new EmployeeSalesDto(x.Id,
                                       x.InvoiceNumber,
                                       x.TotalAmount,
                                       x.CreatedAt)).ToList();

            return Result<List<EmployeeSalesDto>>.Success(response);
        }
    }
}
