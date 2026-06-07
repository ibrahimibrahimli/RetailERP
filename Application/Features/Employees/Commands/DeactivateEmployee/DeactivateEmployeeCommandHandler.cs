using Application.Common.Results;
using Application.Interfaces.Repositories.Read.Common;
using Application.Interfaces.Repositories.Write.Common;
using MediatR;

namespace Application.Features.Employees.Commands.DeactivateEmployee
{
    public sealed record DeactivateEmployeeCommandHandler : IRequestHandler<DeactivateEmployeeCommand, Result>
    {
        private readonly IEmployeeReadRepository _employeeReadRepository;
        private readonly IEmployeeWriteRepository _employeeWriteRepository;

        public DeactivateEmployeeCommandHandler(IEmployeeReadRepository employeeReadRepository, IEmployeeWriteRepository employeeWriteRepository)
        {
            _employeeReadRepository = employeeReadRepository;
            _employeeWriteRepository = employeeWriteRepository;
        }

        public async Task<Result> Handle(DeactivateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeReadRepository.GetByIdAsync(request.EmployeeId);
            if (employee == null)
                return Result.Failure("Employee not found");

            employee.Deactivate();

            await _employeeWriteRepository.SaveChangesAsync();
            return Result.Success();
        }
    }
}
