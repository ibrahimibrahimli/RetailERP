using Domain.Common;

namespace Domain.Entities
{
    public class Branch : BaseEntity
    {
        public string Name { get; private set; }
        public string Address { get; private set; }
        public string PhoneNumber { get; private set; }
        public bool IsActive { get; private set; }
        public Guid BrandId { get; private set; }
        public Brand Brand { get; private set; } = null!;

        private Branch()
        {
        }

        private Branch(
            string name,
            string address,
            string phoneNumber,
            Guid brandId)
        {
            SetName(name);

            SetAddress(address);

            SetPhoneNumber(phoneNumber);

            BrandId = brandId;

            IsActive = true;
        }

        public static Branch Create(
        string name,
        string address,
        string phoneNumber,
        Guid brandId)
        {
            return new Branch(
                name,
                address,
                phoneNumber,
                brandId);
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

        public void UpdateName(string name)
        {
            SetName(name);

            SetUpdatedTime();
        }

        public void UpdateAddress(string address)
        {
            SetAddress(address);

            SetUpdatedTime();
        }

        public void UpdatePhoneNumber(string phoneNumber)
        {
            SetPhoneNumber(phoneNumber);

            SetUpdatedTime();
        }

        public void Delete()
        {
            MarkAsDeleted();

            SetUpdatedTime();
        }

        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(
                    "Branch name cannot ve empty.");
            }

            Name = name.Trim();
        }

        private void SetAddress(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
            {
                throw new ArgumentException(
                    "Address cannot be empty.");
            }

            Address = address.Trim();
        }

        private void SetPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                throw new ArgumentException(
                    "Phone number cannot be empty.");
            }

            PhoneNumber = phoneNumber.Trim();
        }
    }
}
