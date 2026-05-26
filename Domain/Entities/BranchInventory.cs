using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class BranchInventory : BaseEntity
    {
        private readonly List<InventoryTransaction> _transactions = [];
        public Guid ProductVariantId { get; private set; }

        public ProductVariant ProductVariant { get; private set; } = null!;

        public Guid BranchId { get; private set; }

        public Branch Branch { get; private set; } = null!;

        public int Quantity { get; private set; }

        public int MinimumStockLevel { get; private set; }

        public bool IsSelling { get; private set; }

        public IReadOnlyCollection<InventoryTransaction> Transactions => _transactions;

        private BranchInventory()
        {
        }

        private BranchInventory(
            Guid productVariantId,
            Guid branchId,
            int quantity,
            int minimumStockLevel)
        {
            SetQuantity(quantity);

            SetMinimumStockLevel(minimumStockLevel);

            ProductVariantId = productVariantId;

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

        private InventoryTransaction IncreaseStock(int quantity, InventoryTransactionType type, string description, string? source, string? referenceCode)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero");

            Quantity += quantity;

            InventoryTransaction transaction = InventoryTransaction.Create(Id, type, quantity, description, source, referenceCode);
            AddTransaction(transaction);

            SetUpdatedTime();
            return transaction;
        }

        private InventoryTransaction DecreaseStock(int quantity, InventoryTransactionType type, string description, string? source, string? referenceCode)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero");

            if (Quantity < quantity)
                throw new InvalidOperationException("Insuffient Stock");

            Quantity -= quantity;

            InventoryTransaction transaction = InventoryTransaction.Create(Id, type, quantity, description);

            AddTransaction(transaction);
            SetUpdatedTime();
            return transaction;
        }
        public InventoryTransaction SellProduct(int quantity, string referenceCode)
        {
            return DecreaseStock(
                quantity,
                InventoryTransactionType.Sale,
                "Product sold.",
                "Sold",
                referenceCode);
        }

        public InventoryTransaction AddStock(int quantity, string referenceCode)
        {
             return IncreaseStock(
                quantity,
                InventoryTransactionType.AddStock,
                "Stock added.",
                "Stock",
                referenceCode);
        }

        public InventoryTransaction TransferOut(int quantity, string referenceCode)
        {
           return DecreaseStock(
                quantity,
                InventoryTransactionType.TransferOut,
                "Stock transferred out.",
                "Transfer",
                referenceCode);
        }

        public InventoryTransaction TransferIn(int quantity, string referenceCode)
        {
            return IncreaseStock(
                quantity,
                InventoryTransactionType.TransferIn,
                "Stock transferred in.",
                "Transfer",
                referenceCode);
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

        public void AddTransaction(InventoryTransaction transaction)
        {
            _transactions.Add(transaction);
        }
    }
}
