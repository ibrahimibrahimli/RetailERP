using Domain.Common;
using RetailERP.Domain.Entities;

namespace Domain.Entities
{
    public class BranchInventory : BaseEntity
    {
        public Guid ProductId { get; private set; }

        public Product Product { get; private set; } = null!;

        public Guid BranchId { get; private set; }

        public Branch Branch { get; private set; } = null!;

        public int Quantity { get; private set; }

        public int MinimumStockLevel { get; private set; }

        public bool IsSelling { get; private set; }

        private BranchInventory()
        {
        }

        private BranchInventory(
            Guid productId,
            Guid branchId,
            int quantity,
            int minimumStockLevel)
        {
            SetQuantity(quantity);

            SetMinimumStockLevel(minimumStockLevel);

            ProductId = productId;

            BranchId = branchId;

            IsSelling = true;
        }

        public static BranchInventory Create(
        Guid productId,
        Guid branchId,
        int quantity,
        int minimumStockLevel)
        {
            return new BranchInventory(
                productId,
                branchId,
                quantity,
                minimumStockLevel);
        }

        public void IncreaseStock(int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException(
                    "Quantity must be greater than zero.");
            }

            Quantity += quantity;

            SetUpdatedTime();
        }

        public void DecreaseStock(int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException(
                    "Quantity must be greater than zero.");
            }

            if (Quantity < quantity)
            {
                throw new InvalidOperationException(
                    "Insufficient stock.");
            }

            Quantity -= quantity;

            SetUpdatedTime();
        }

        public void ChangeMinimumStockLevel(int level)
        {
            SetMinimumStockLevel(level);

            SetUpdatedTime();
        }

        public void StartSelling()
        {
            IsSelling = true;

            SetUpdatedTime();
        }

        public void StopSelling()
        {
            IsSelling = false;

            SetUpdatedTime();
        }

        public void Delete()
        {
            MarkAsDeleted();

            SetUpdatedTime();
        }

        private void SetQuantity(int quantity)
        {
            if (quantity < 0)
            {
                throw new ArgumentException(
                    "Quantity cannot be negative.");
            }

            Quantity = quantity;
        }

        private void SetMinimumStockLevel(int level)
        {
            if (level < 0)
            {
                throw new ArgumentException(
                    "Minimum stock level cannot be negative.");
            }

            MinimumStockLevel = level;
        }
    }
}
