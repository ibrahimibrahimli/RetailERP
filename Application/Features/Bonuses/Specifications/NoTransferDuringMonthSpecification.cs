using Application.Common.Specifications;
using Domain.Entities;

namespace Application.Features.Bonuses.Specifications
{
    public sealed class NoTransferDuringMonthSpecification : ISpecification<Employee>
    {
        private readonly IReadOnlyCollection<EmployeeTransfer> _transfers;
        private readonly int _year;
        private readonly int _month;

        public NoTransferDuringMonthSpecification(IReadOnlyCollection<EmployeeTransfer> transfers, int year, int month)
        {
            _transfers = transfers;
            _year = year;
            _month = month;
        }

        public bool IsSatisfiedBy(Employee employee)
        {
            return _transfers.Any(x =>
            x.EmployeeId == employee.Id &&
            x.TransferDate.Year == _year &&
            x.TransferDate.Month == _month);
        }
    }
}
