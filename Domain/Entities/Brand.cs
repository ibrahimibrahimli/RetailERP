using Domain.Common;

namespace Domain.Entities
{
    public class Brand : BaseEntity
    {
        public string Name { get; private set; }

        public bool IsActive { get; private set; }

        public Guid SubCompanyId { get; private set; }

        public SubCompany SubCompany { get; private set; } = null!;

        private Brand()
        {
        }

        public Brand(
            string name,
            Guid subCompanyId)
        {
            SetName(name);

            SubCompanyId = subCompanyId;

            IsActive = true;
        }

        public void Activate()
        {
            IsActive = true;
        }

        public void Deactivate()
        {
            IsActive = false;
        }

        public void UpdateName(string name)
        {
            SetName(name);
        }

        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Brand name cannot be empty.");

            Name = name;
        }
    }
}
