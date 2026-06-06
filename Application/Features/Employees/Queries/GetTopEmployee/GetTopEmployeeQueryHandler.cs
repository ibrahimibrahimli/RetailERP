using Application.Common.Results;
using Application.Features.Employees.DTOs;
using Application.Interfaces.Repositories.Read.Common;
using MediatR;

namespace Application.Features.Employees.Queries.GetTopEmployee
{
    public sealed class GetTopEmployeeQueryHandler : IRequestHandler<GetTopEmployeeQuery, Result<List<TopEmployeeDto>>>
    {
        private readonly IEmployeeReadRepository _employeeReadRepository;
        public GetTopEmployeeQueryHandler(IEmployeeReadRepository employeeReadRepository)
        {
            _employeeReadRepository = employeeReadRepository;
        }

        public async Task<Result<List<TopEmployeeDto>>> Handle(GetTopEmployeeQuery request, CancellationToken cancellationToken)
        {
            var topEmployees = await _employeeReadRepository.GetTopEmployeesAsync(request.count);
            if (topEmployees == null)
                return Result<List<TopEmployeeDto>>.Failure("Top employees not found");

            return Result<List<TopEmployeeDto>>.Success(topEmployees);
        }
    }
}
