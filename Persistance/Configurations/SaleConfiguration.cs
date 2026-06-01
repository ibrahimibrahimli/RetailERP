using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configurations
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sales");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.InvoiceNumber)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.TotalAmount)
                .HasPrecision(18, 2);

            builder.Property(x => x.PaymentMethod)
                .IsRequired();

            builder.Property(x => x.SaleDate)
                .IsRequired();

            builder.HasOne(x => x.Branch)
                .WithMany()
                .HasForeignKey(x => x.BranchId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Items)
                .WithOne(x => x.Sale)
                .HasForeignKey(x => x.SaleId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Navigation(x => x.Items)
                .UsePropertyAccessMode(
                    PropertyAccessMode.Field);

            builder.HasOne(x => x.Employee)
                .WithMany()
                .HasForeignKey(x => x.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
