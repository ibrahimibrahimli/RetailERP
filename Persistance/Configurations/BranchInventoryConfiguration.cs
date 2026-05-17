using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class BranchInventoryConfiguration : IEntityTypeConfiguration<BranchInventory>
{
    public void Configure(EntityTypeBuilder<BranchInventory> builder)
    {
        builder.ToTable("BranchInventories");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Quantity)
            .IsRequired();

        builder.Property(x => x.MinimumStockLevel)
            .IsRequired();

        builder.Property(x => x.IsSelling)
            .IsRequired();

        builder.HasOne(x => x.Product)
            .WithMany(x => x.BranchInventories)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Branch)
            .WithMany(x => x.BranchInventories)
            .HasForeignKey(x => x.BranchId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.Transactions)
            .WithOne(x => x.BranchInventory)
            .HasForeignKey(x => x.BranchInventoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Navigation(x => x.Transactions)
            .UsePropertyAccessMode(PropertyAccessMode.Field);

        builder.HasIndex(x => new
        {
            x.ProductId,
            x.BranchId
        })
        .IsUnique();
    }
}