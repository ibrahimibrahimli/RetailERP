using Application.Common.Specifications;
using Domain.Entities;

namespace Application.Features.Bonuses.Specifications
{
    public sealed class WorkedFullMonthSpecification : ISpecification<Employee>
    {
        private readonly int _year;
        private readonly int _month;

        public WorkedFullMonthSpecification(int year, int month)
        {
            _year = year;
            _month = month;
        }

        public SpecificationResult IsSatisfiedBy(Employee employee)
        {
            var firstDayOfMonth = new DateOnly(_year, _month, 1);
            return employee.HireDate <= firstDayOfMonth ? new(true) : new(false, "Employee has not worked the full month");
        }
    }
}
