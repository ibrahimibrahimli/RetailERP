using Domain.Common;

namespace Domain.Entities
{
    public class SubCompany : BaseEntity
    {
        private readonly List<Brand> _brands = [];
        public string Name { get; set; } = null;
        public bool IsActive { get; set; } = true;

        public IReadOnlyCollection<Brand> Brands => _brands.AsReadOnly();

        private SubCompany() { }


        public SubCompany(string name)
        {
            SetName(name);
            IsActive = true;
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

        public void AddBrand(Brand brand)
        {
            _brands.Add(brand);

            SetUpdatedTime();
        }

        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(
                    "SubCompany name cannot be empty.");

            Name = name;
        }
    }
}
