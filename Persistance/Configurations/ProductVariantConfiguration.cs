using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configurations
{
    public sealed class ProductVariantConfiguration : IEntityTypeConfiguration<ProductVariant>
    {
        public void Configure(EntityTypeBuilder<ProductVariant> builder)
        {
            builder.ToTable("ProductVariants");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Color)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Size)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.SKU)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Barcode)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(x => x.SKU)
                .IsUnique();

            builder.HasIndex(x => x.Barcode)
                .IsUnique();

            builder.HasOne(x => x.Product)
                .WithMany(x => x.Variants)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
