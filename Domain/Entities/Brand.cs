using Domain.Common;

namespace Domain.Entities
{
    public class Brand : BaseEntity
    {
        public string Name { get; set; } = null!;

        public bool IsActive { get; set; } = true;

        public Guid SubCompanyId { get; set; }

        public SubCompany SubCompany { get; set; } = null!;
    }
}
