using Application.Common.Results;
using Application.Features.Bonuses.DTOs;
using Application.Features.Bonuses.Specifications;
using Application.Interfaces.Repositories.Read.Common;
using MediatR;

namespace Application.Features.Bonuses.Queries
{
    public sealed class CheckBonusEligibilityQueryHandler : IRequestHandler<CheckBonusEligibilityQuery, Result<BonusEligibilityDto>
    {
        private readonly IEmployeeReadRepository _employeeReadRepository;
        private readonly IEmployeeTransferReadRepository _employeeTransferReadRepository;
        public CheckBonusEligibilityQueryHandler(IEmployeeReadRepository employeeReadRepository, IEmployeeTransferReadRepository employeeTransferReadRepository)
        {
            _employeeReadRepository = employeeReadRepository;
            _employeeTransferReadRepository = employeeTransferReadRepository;
        }

        public async Task<Result<BonusEligibilityDto>> Handle(CheckBonusEligibilityQuery request, CancellationToken cancellationToken)
        {
            var employee = await _employeeReadRepository.GetByIdAsync(request.EmployeeId);
            if (employee is null)
                return Result<BonusEligibilityDto>.Failure("Employee not found");

            var transfers = await _employeeTransferReadRepository.GetByEmployeeAsync(request.EmployeeId);
            if (transfers is null)
                return Result<BonusEligibilityDto>.Failure("Transfer not found");

            var specification = new NoTransferDuringMonthSpecification(
                transfers,
                request.Year,
                request.Month);

            if (!specification.IsSatisfiedBy(employee))
                return Result<BonusEligibilityDto>.Success(new(employee.Id,
                                                               false,
                                                               "Employee was transferred during the selected month."));

            return Result<BonusEligibilityDto>.Success(new(
                employee.Id,
                true,
                null));
        }
    }
}
