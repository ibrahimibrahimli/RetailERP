using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configurations
{
    public sealed class BonusRuleConfiguration : IEntityTypeConfiguration<BonusRule>
    {
        public void Configure(EntityTypeBuilder<BonusRule> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.MinimumSales)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(x => x.MaximumSales)
                .HasPrecision(18, 2);

            builder.Property(x => x.BonusValue)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(x => x.BonusType)
                .HasConversion<int>()
                .IsRequired();

            builder.Property(x => x.EffectiveFrom)
                .IsRequired();

            builder.Property(x => x.EffectiveTo);

            builder.Property(x => x.IsActive)
                .IsRequired();

            builder.HasOne(x => x.Position)
                .WithMany()
                .HasForeignKey(x => x.PositionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
