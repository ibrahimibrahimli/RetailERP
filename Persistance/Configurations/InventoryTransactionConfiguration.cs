using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configurations
{
    public class InventoryTransactionConfiguration : IEntityTypeConfiguration<InventoryTransaction>
    {
        public void Configure(EntityTypeBuilder<InventoryTransaction> builder)
        {
            builder.ToTable("InventoryTransactions");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Quantity)
                .IsRequired();

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(x => x.Type)
                .IsRequired();

            builder.Property(x => x.Source)
                .HasMaxLength(100);

            builder.Property(x => x.ReferenceCode)
                .HasMaxLength(100);

            builder.HasOne(x => x.BranchInventory)
                .WithMany(x => x.Transactions)
                .HasForeignKey(x => x.BranchInventoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
