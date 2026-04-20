using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configurations
{
    public class SubCompanyConfiguration : IEntityTypeConfiguration<SubCompany>
    {
        public void Configure(EntityTypeBuilder<SubCompany> builder)
        {
            builder.ToTable("SubCompanies");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.IsActive)
                .IsRequired();

            builder.Metadata
                .FindNavigation(nameof(SubCompany.Brands))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
