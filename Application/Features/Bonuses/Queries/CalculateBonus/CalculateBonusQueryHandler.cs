using Application.Common.Results;
using Application.Features.Bonuses.DTOs;
using Application.Features.Bonuses.Factories;
using Application.Interfaces.Repositories.Read.Common;
using MediatR;

namespace Application.Features.Bonuses.Queries.CalculateBonus
{
    public class CalculateBonusQueryHandler : IRequestHandler<CalculateBonusQuery, Result<BonusCalculationResult   > >
    {
        private readonly IEmployeeReadRepository _employeeReadRepository;
        private readonly IBonusRuleReadRepository _bonusRuleReadRepository;
        private readonly ISaleReadRepository _saleReadRepository;
        private readonly IEmployeeTransferReadRepository _employeeTransferReadRepository;
        private readonly IEmployeeBonusEligibilitySpecificationFactory _eligibilityFactory;
        private readonly IBonusStrategyFactory _strategyFactory;

        public CalculateBonusQueryHandler(IEmployeeReadRepository employeeReadRepository,
                                          IBonusRuleReadRepository bonusRuleReadRepository,
                                          ISaleReadRepository saleReadRepository,
                                          IEmployeeTransferReadRepository employeeTransferReadRepository,
                                          IEmployeeBonusEligibilitySpecificationFactory eligibilityFactory,
                                          IBonusStrategyFactory strategyFactory)
        {
            _employeeReadRepository = employeeReadRepository;
            _bonusRuleReadRepository = bonusRuleReadRepository;
            _saleReadRepository = saleReadRepository;
            _employeeTransferReadRepository = employeeTransferReadRepository;
            _eligibilityFactory = eligibilityFactory;
            _strategyFactory = strategyFactory;
        }

        public async Task<Result<BonusCalculationResult>> Handle(CalculateBonusQuery request, CancellationToken cancellationToken)
        {
            var employee = await _employeeReadRepository.GetByIdAsync(request.EmployeeId);
            if (employee is null)
                return Result<BonusCalculationResult>
                    .Failure("Employee not found.");

            var transfers = await _employeeTransferReadRepository.GetByEmployeeAsync(request.EmployeeId);

            var eligibilitySpecification = _eligibilityFactory.Create(transfers, request.Year, request.Month);

            var eligibilityResult = eligibilitySpecification.Evaluate(employee);
            if(!eligibilityResult.IsSatisfied)
                return Result<BonusCalculationResult>.Failure(eligibilityResult.Reason!);

            var personalSales = await _saleReadRepository.GetEmployeePersonalSalesAsync(
                request.EmployeeId, request.Year, request.Month, cancellationToken);

            var storeSales = await _saleReadRepository.GetStoreSalesAsync(
                employee.BranchId,
                request.Year,
                request.Month,
                cancellationToken);

            var employeeRankings = await _saleReadRepository.GetEmployeeSalesRankingAsync(
                request.Year,
                request.Month,
                employee.PositionId,
                cancellationToken);


            var rules = await _bonusRuleReadRepository.GetActiveRulesAsync(
                employee.PositionId,
                request.Year,
                request.Month,
                cancellationToken);

            if(rules.Count == 0)
                return Result<BonusCalculationResult>.Failure("No active bonus rule found for the employee.");

            var context = new BonusCalculationContext(
                employee.Id,
                employee.PositionId,
                employee.BranchId,
                personalSales,
                storeSales,
                new DateOnly(request.Year, request.Month, 1),
                employeeRankings);

            var strategy = _strategyFactory.Create(rules.First().BonusType);

            var result = strategy.Calculate(context, rules);

            return Result<BonusCalculationResult>.Success(result);
        }
    }
}
