using Application.Common.Results;
using Application.Features.Employees.DTOs;
using Application.Interfaces.Repositories.Read.Common;
using MediatR;

namespace Application.Features.Employees.Queries.GetAllEmployees
{
    public sealed record GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, Result<List<EmployeeDto>>>
    {
        private readonly IEmployeeReadRepository _employeeReadRepository;

        public GetAllEmployeesQueryHandler(IEmployeeReadRepository employeeReadRepository)
        {
            _employeeReadRepository = employeeReadRepository;
        }

        public async Task<Result<List<EmployeeDto>>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = await _employeeReadRepository.GetAllByBranchAsync();
            if (employees == null)
                return Result<List<EmployeeDto>>.Failure("Employee not found");

            var response = employees.Select(x => new EmployeeDto(
                x.Id,
                x.EmployeeCode,
                x.FirstName,
                x.LastName,
                x.IsActive,
                x.BranchId,
                x.Branch.Name)).ToList();

            return Result<List<EmployeeDto>>.Success(response);
        }
    }
}
