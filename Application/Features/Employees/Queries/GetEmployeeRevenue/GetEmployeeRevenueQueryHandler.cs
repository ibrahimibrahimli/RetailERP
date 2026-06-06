using Application.Common.Results;
using Application.Features.Employees.DTOs;
using Application.Interfaces.Repositories.Read.Common;
using MediatR;

namespace Application.Features.Employees.Queries.GetEmployeeRevenue
{
    public sealed class GetEmployeeRevenueQueryHandler : IRequestHandler<GetEmployeeRevenueQuery, Result<EmployeeRevenueDto>>
    {
        private readonly ISaleReadRepository _saleReadRepository;

        public GetEmployeeRevenueQueryHandler(ISaleReadRepository saleReadRepository)
        {
            _saleReadRepository = saleReadRepository;
        }

        public async Task<Result<EmployeeRevenueDto>> Handle(GetEmployeeRevenueQuery request, CancellationToken cancellationToken)
        {
            var sales = await _saleReadRepository.GetByEmployeeAsync(request.EmployeeId);
            if (sales == null)
                return Result<EmployeeRevenueDto>.Failure("Sales not found");

            EmployeeRevenueDto response = new(
                request.EmployeeId,
                sales.Count,
                sales.Sum(x => x.TotalAmount));

            return Result<EmployeeRevenueDto>.Success(response);
        }
    }
}
