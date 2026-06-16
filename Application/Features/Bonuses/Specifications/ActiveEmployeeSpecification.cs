using Application.Common.Specifications;
using Domain.Entities;

namespace Application.Features.Bonuses.Specifications
{
    public sealed class ActiveEmployeeSpecification : ISpecification<Employee>
    {
        public SpecificationResult IsSatisfiedBy(Employee employee)
        {
            return employee.IsActive ? new(true) : new(false, "Employee is not active");
        }
    }
}
