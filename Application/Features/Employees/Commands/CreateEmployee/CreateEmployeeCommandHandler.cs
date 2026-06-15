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
        private readonly IPositionReadRepository _positionReadRepository;

        public CreateEmployeeCommandHandler(IBranchReadRepository branchReadRepository, IEmployeeWriteRepository employeeWriteRepository, IPositionReadRepository positionReadRepository)
        {
            _branchReadRepository = branchReadRepository;
            _employeeWriteRepository = employeeWriteRepository;
            _positionReadRepository = positionReadRepository;
        }

        public async Task<Result<Guid>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var branch = await _branchReadRepository.GetByIdAsync(request.BranchId);
            if (branch == null)
                return Result<Guid>.Failure("Branch not found");

            var position = await _positionReadRepository.GetByIdAsync(request.PositionId);
            if(position == null)
                return Result<Guid>.Failure("Position not found");

            Employee employee = Employee.Create(
                request.BranchId,
                request.PositionId, 
                request.FirstName,
                request.LastName,
                request.EmployeeCode,
                request.HireDate);

            await _employeeWriteRepository.AddAsync(employee);
            await _employeeWriteRepository.SaveChangesAsync();

            return Result<Guid>.Success(employee.Id);
        }
    }
}
