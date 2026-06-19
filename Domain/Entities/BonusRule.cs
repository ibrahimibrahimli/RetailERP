using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public sealed class BonusRule : BaseEntity
    {
        public BonusType BonusType { get; private set; }

        public Guid PositionId { get; private set; }
        public Position Position { get; private set; } = default!;

        public decimal MinimumSales { get; private set; }

        public decimal? MaximumSales { get; private set; }
        public DateOnly EffectiveFrom { get; private set; }
        public DateOnly? EffectiveTo { get; private set; }

        public decimal BonusValue { get; private set; }

        public bool IsActive { get; private set; }

        private BonusRule()
        {
        }

        private BonusRule(
            BonusType bonusType,
            Guid positionId,
            decimal minimumSales,
            decimal? maximumSales,
            decimal bonusValue)
        {
            BonusType = bonusType;
            PositionId = positionId;
            MinimumSales = minimumSales;
            MaximumSales = maximumSales;
            BonusValue = bonusValue;
            IsActive = true;
        }

        public static BonusRule Create(
            BonusType bonusType,
            Guid positionId,
            decimal minimumSales,
            decimal? maximumSales,
            decimal bonusValue)
        {
            return new BonusRule(
                bonusType,
                positionId,
                minimumSales,
                maximumSales,
                bonusValue);
        }

        public void Deactivate()
        {
            IsActive = false;
        }

        public void Activate()
        {
            IsActive = true;
        }   
    }
}
