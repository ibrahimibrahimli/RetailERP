using Domain.Common;

namespace Domain.Entities
{
    public class SaleItem : BaseEntity
    {
        public Guid SaleId { get; private set; }
        public Sale Sale { get; private set; } = null!;
        public Guid ProductId { get; private set; }
        public string ProductName { get; private set; }
        public decimal UnitPrice { get; private set; }
        public int Quantity { get; private set; }
        public decimal TotalPrice { get; private set; }
        public Guid ProductVariantId { get; private set; }
        public string Color{ get; private set; }
        public string Size{ get; private set; }
        public string SKU{ get; private set; }


        private SaleItem() { }

        private SaleItem(Guid productId,
            string productName,
            decimal unitPrice,
            int quantity)
        {
            ProductId = productId;
            ProductName = productName;
            SetUnitPrice(unitPrice);
            SetQuantity(quantity);
            CalculateTotalPrice();
        }

        public static SaleItem Create(Guid productId,
            string productName,
            decimal unitPrice,
            int quantity)
        {
            return new SaleItem(productId, productName, unitPrice, quantity);
        }

        private void SetUnitPrice(decimal price)
        {
            if(price <= 0)
                throw new ArgumentException("Price must be greater than zero");

            UnitPrice = price;
        }

        private void SetQuantity(int quantity) 
        {
            if (quantity <= 0) throw new ArgumentException("Quantiy must be greater than zero");

            Quantity = quantity;
        }

        private void CalculateTotalPrice()
        {
            TotalPrice = UnitPrice * Quantity;
        }
    }
}