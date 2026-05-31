using Domain.Common;

namespace Domain.Entities
{
    public class Employee : BaseEntity
    {
        public  Guid BranchId { get; private set; }
        public Branch Branch { get; private set; } = null!;
        public string FirstName { get; private set; } = null!;
        public string LastName { get; private set; } = null!;
        public string EmployeeCode { get; private set; } = null!;
        public bool IsActive { get; private set; }

        private Employee() {}

        public Employee(Guid branchId, string firstName, string lastName, string employeeCode)
        {
            BranchId = branchId;
            SetFirstName(firstName);
            SetLastName(lastName);
            SetEmployeeCode(employeeCode);
            IsActive = true;
        }

        public static Employee Create(Guid branchId, string firstName, string  lastName, string employeeCode)
        {
            return new Employee(branchId, firstName, lastName, employeeCode);
        }

        public void Activate()
        {
            IsActive = true;
            SetUpdatedTime();
        }

        public void Deactivate()
        {
            IsActive = false;
            SetUpdatedTime();
        }

        private void SetFirstName(string firstName)
        {
            if (string.IsNullOrEmpty(firstName))
                throw new ArgumentNullException("First name cannot be empty");

            FirstName = firstName.Trim();
        }

        private void SetLastName(string lastName)
        {
            if (string.IsNullOrEmpty(lastName))
                throw new ArgumentNullException("Last name cannot be empty");

            LastName = lastName.Trim();
        }

        private void SetEmployeeCode(string employeeCode)
        {
            if (string.IsNullOrEmpty(employeeCode))
                throw new ArgumentNullException("First name cannot be empty");

            EmployeeCode = employeeCode.Trim();
        }
    }
}
