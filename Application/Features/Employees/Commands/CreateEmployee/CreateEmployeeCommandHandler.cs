using Application.Common.Results;
using Application.Interfaces.Repositories.Read.Common;
using Application.Interfaces.Repositories.Write.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Employees.Commands.CreateEmployee
{
    public sealed class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Result<Guid>>
    {
        private readonly IBranchReadRepository _branchReadRepository;
        private readonly IEmployeeWriteRepository _employeeWriteRepository;

        public CreateEmployeeCommandHandler(IBranchReadRepository branchReadRepository, IEmployeeWriteRepository employeeWriteRepository)
        {
            _branchReadRepository = branchReadRepository;
            _employeeWriteRepository = employeeWriteRepository;
        }

        public async Task<Result<Guid>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var branch = await _branchReadRepository.GetByIdAsync(request.BranchId);
            if (branch == null)
                return Result<Guid>.Failure("Branch not found");

            Employee employee = Employee.Create(
                request.BranchId,
                request.FirstName,
                request.LastName,
                request.EmployeeCode);

            await _employeeWriteRepository.AddAsync(employee);
            await _employeeWriteRepository.SaveChangesAsync();

            return Result<Guid>.Success(employee.Id);
        }
    }
}
