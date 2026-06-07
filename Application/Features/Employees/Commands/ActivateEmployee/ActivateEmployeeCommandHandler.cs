using Application.Common.Results;
using Application.Interfaces.Repositories.Read.Common;
using Application.Interfaces.Repositories.Write.Common;
using MediatR;

namespace Application.Features.Employees.Commands.ActivateEmployee
{
    public sealed class ActivateEmployeeCommandHandler : IRequestHandler<ActivateEmployeeCommand, Result>
    {
        private readonly IEmployeeReadRepository  _employeeReadRepository;
        private readonly IEmployeeWriteRepository _employeeWriteRepository;
        public ActivateEmployeeCommandHandler(IEmployeeReadRepository employeeReadRepository, IEmployeeWriteRepository employeeWriteRepository)
        {
            _employeeReadRepository = employeeReadRepository;
            _employeeWriteRepository = employeeWriteRepository;
        }

        public async Task<Result> Handle(ActivateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeReadRepository.GetByIdAsync(request.Id);
            if (employee == null)
                return Result.Failure("Employee not found");

            employee.Activate();

            await _employeeWriteRepository.SaveChangesAsync();

            return Result.Success();
        }
    }
}
