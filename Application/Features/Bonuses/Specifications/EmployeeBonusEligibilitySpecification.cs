using Application.Common.Specifications;
using Domain.Entities;

namespace Application.Features.Bonuses.Specifications
{
    public sealed class EmployeeBonusEligibilitySpecification : ISpecification<Employee>
    {
        private readonly IEnumerable<ISpecification<Employee>> _specifications;

        public EmployeeBonusEligibilitySpecification(params ISpecification<Employee>[] specifications)
        {
            _specifications = specifications;
        }

        public SpecificationResult Evaluate(Employee employee)
        {
            foreach (var specification in _specifications)
            {
                var result = specification.IsSatisfiedBy(employee);
                if(!result.IsSatisfied)
                    return result;
            }

            return new(true);
        }
    }
}
