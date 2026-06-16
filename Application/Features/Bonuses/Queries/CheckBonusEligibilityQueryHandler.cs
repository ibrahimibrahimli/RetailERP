using Application.Common.Results;
using Application.Features.Bonuses.DTOs;
using Application.Features.Bonuses.Factories;
using Application.Interfaces.Repositories.Read.Common;
using MediatR;

namespace Application.Features.Bonuses.Queries
{
    public sealed class CheckBonusEligibilityQueryHandler : IRequestHandler<CheckBonusEligibilityQuery, Result<BonusEligibilityDto>>
    {
        private readonly IEmployeeReadRepository _employeeReadRepository;
        private readonly IEmployeeTransferReadRepository _employeeTransferReadRepository;
        private readonly IEmployeeBonusEligibilitySpecificationFactory _factory;
        public CheckBonusEligibilityQueryHandler(IEmployeeReadRepository employeeReadRepository, IEmployeeTransferReadRepository employeeTransferReadRepository, IEmployeeBonusEligibilitySpecificationFactory factory)
        {
            _employeeReadRepository = employeeReadRepository;
            _employeeTransferReadRepository = employeeTransferReadRepository;
            _factory = factory;
        }

        public async Task<Result<BonusEligibilityDto>> Handle(CheckBonusEligibilityQuery request, CancellationToken cancellationToken)
        {
            var employee = await _employeeReadRepository.GetByIdAsync(request.EmployeeId);
            if (employee is null)
                return Result<BonusEligibilityDto>.Failure("Employee not found");


            var transfers = await _employeeTransferReadRepository.GetByEmployeeAsync(request.EmployeeId);

            var specification = _factory.Create(transfers, request.Year, request.Month);

            var evaluationResult = specification.Evaluate(employee);
            if (!evaluationResult.IsSatisfied)
                return Result<BonusEligibilityDto>.Success(new(
                    employee.Id,
                    false,
                    evaluationResult.Reason));

            return Result<BonusEligibilityDto>.Success(new(
                employee.Id,
                true,
                null));
        }
    }
}
