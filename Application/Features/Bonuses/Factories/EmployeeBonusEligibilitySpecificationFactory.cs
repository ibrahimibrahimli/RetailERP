using Application.Features.Bonuses.Specifications;
using Domain.Entities;

namespace Application.Features.Bonuses.Factories
{
    public sealed class EmployeeBonusEligibilitySpecificationFactory : IEmployeeBonusEligibilitySpecificationFactory
    {
        public EmployeeBonusEligibilitySpecification Create(List<EmployeeTransfer> transfers, int year, int month)
        {
            return new EmployeeBonusEligibilitySpecification(
                new ActiveEmployeeSpecification(),
                new NoTransferDuringMonthSpecification(transfers, year, month),
                new WorkedFullMonthSpecification(year, month));
        }
    }
}
