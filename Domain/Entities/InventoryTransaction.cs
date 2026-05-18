using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class InventoryTransaction : BaseEntity
    {
        public Guid BranchInventoryId { get; private set; }
        public BranchInventory BranchInventory { get; private set; } = null!;
        public InventoryTransactionType Type { get; private set; }
        public int Quantity { get; private set; }
        public string Description { get; private set; }
        public string? ReferenceCode { get; private set;}
        public string? Source { get; private set; }


        private InventoryTransaction()
        {
        }

        private InventoryTransaction(
            Guid branchInventoryId,
            InventoryTransactionType type,
            int quantity,
            string description,
            string? source,
            string? referenceCode)
        {
            BranchInventoryId = branchInventoryId;

            Type = type;
            Source = source;
            ReferenceCode = referenceCode;

            SetQuantity(quantity);

            SetDescription(description);
        }

        public static InventoryTransaction Create(
            Guid branchInventoryId,
            InventoryTransactionType type,
            int quantity,
            string description,
            string? source = null,
            string? referenceCode = null)
        {
            return new InventoryTransaction(
                branchInventoryId,
                type,
                quantity,
                description,
                source,
                referenceCode);
        }

        private void SetQuantity(int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException(
                    "Quantity must be greater than zero.");
            }

            Quantity = quantity;
        }

        private void SetDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException(
                    "Description cannot be empty.");
            }

            Description = description.Trim();
        }
    }
}
