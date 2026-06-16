using Application.Features.Bonuses.Specifications;
using Domain.Entities;

namespace Application.Features.Bonuses.Factories
{
    public interface IEmployeeBonusEligibilitySpecificationFactory
    {
        EmployeeBonusEligibilitySpecification Create(
            List<EmployeeTransfer> transfers,
            int year,
            int month);
    }
}
