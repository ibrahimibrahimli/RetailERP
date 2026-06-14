using Application.Common.Specifications;
using Domain.Entities;

namespace Application.Features.Bonuses.Specifications
{
    public sealed class ActiveEmployeeSpecification : ISpecification<Employee>
    {
        public bool IsSatisfiedBy(Employee employee)
        {
            return employee.IsActive;
        }
    }
}
