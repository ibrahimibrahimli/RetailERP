using Domain.Common;
using RetailERP.Domain.Entities;

namespace Domain.Entities
{
    public class Brand : BaseEntity
    {
        private readonly List<Branch> _branches = [];
        private readonly List<Product> _products = [];
        public string Name { get; private set; }

        public bool IsActive { get; private set; }

        public Guid SubCompanyId { get; private set; }

        public SubCompany SubCompany { get; private set; } = null!;


        public IReadOnlyCollection<Branch> Branches => _branches.AsReadOnly();
        public IReadOnlyCollection<Product> Products => _products.AsReadOnly();


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

        public void AddBranch(Branch branch)
        {
            _branches.Add(branch);

            SetUpdatedTime();
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);

            SetUpdatedTime();
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

        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Brand name cannot be empty.");

            Name = name;
        }

        public void Delete()
        {
            MarkAsDeleted();
            SetUpdatedTime();
        }
    }
}
