using Application.Common.Results;
using Application.Interfaces;
using Application.Interfaces.Repositories.Read.Common;
using Application.Interfaces.Repositories.Write.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.TransferEmployee.Commands.CreateEmployeeTransfer
{
    public sealed class CreateEmployeeTransferCommandHandler : IRequestHandler<CreateEmployeeTransferCommand, Result>
    {
        private readonly IEmployeeReadRepository _employeeReadRepository;
        private readonly IBranchReadRepository _branchReadRepository;
        private readonly IPositionReadRepository _positionReadRepository;
        private readonly IEmployeeTransferWriteRepository _employeeTransferWriteRepository;
        private readonly IUnitOfWork _unitOfWork;


        public CreateEmployeeTransferCommandHandler(IEmployeeReadRepository employeeReadRepository, IBranchReadRepository branchReadRepository, IPositionReadRepository positionReadRepository, IEmployeeTransferWriteRepository employeeTransferWriteRepository, IUnitOfWork unitOfWork)
        {
            _employeeReadRepository = employeeReadRepository;
            _branchReadRepository = branchReadRepository;
            _positionReadRepository = positionReadRepository;
            _employeeTransferWriteRepository = employeeTransferWriteRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CreateEmployeeTransferCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeReadRepository.GetByIdAsync(request.EmployeeId);
            if (employee == null)
                return Result.Failure("Employee not found");

            var branch = await _branchReadRepository.GetByIdAsync(request.NewBranchId);
            if (branch is null)
                return Result.Failure("Branch not found");

            var position = await _positionReadRepository.GetByIdAsync(request.NewPositionId);
            if (position is null)
                return Result.Failure("Position not found");

            var transfer = EmployeeTransfer.Create(
                employee.Id,
                employee.BranchId,
                request.NewBranchId,
                employee.PositionId,
                request.NewPositionId,
                request.TransferDate,
                request.Reason);

            employee.ChangeBranch(request.NewBranchId);
            employee.ChangePosition(request.NewPositionId);

            await _employeeTransferWriteRepository.AddAsync(transfer);
            await _unitOfWork.SaveChangesAsync();

        }
    }
}
