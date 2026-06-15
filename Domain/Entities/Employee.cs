using Domain.Common;

namespace Domain.Entities
{
    public class Employee : BaseEntity
    {
        public  Guid BranchId { get; private set; }
        public Branch Branch { get; private set; } = null!;
        public  Guid PositionId { get; private set; }
        public Position Position { get; private set; }
        public string FirstName { get; private set; } = null!;
        public string LastName { get; private set; } = null!;
        public string EmployeeCode { get; private set; } = null!;
        public DateOnly HireDate { get; private set; }
        public bool IsActive { get; private set; }

        private Employee() {}

        private Employee(Guid branchId, Guid positionId, string firstName, string lastName, string employeeCode, DateOnly hireDate)
        {
            BranchId = branchId;
            PositionId = positionId;
            SetFirstName(firstName);
            SetLastName(lastName);
            SetEmployeeCode(employeeCode);
            IsActive = true;
            HireDate = hireDate;
        }

        public static Employee Create(Guid branchId, Guid positionId, string firstName, string  lastName, string employeeCode, DateOnly hireDate)
        {
            return new Employee(branchId, positionId, firstName, lastName, employeeCode, hireDate);
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

        public void ChangePosition(Guid positionId)
        {
            if (positionId == Guid.Empty)
                throw new ArgumentException("Position is required");

            PositionId = positionId;
        }

        public void ChangeBranch(Guid branchId)
        {
            if (branchId == Guid.Empty)
                throw new ArgumentException("Branch not found");

            BranchId = branchId;
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
