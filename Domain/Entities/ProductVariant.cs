using Domain.Common;
using RetailERP.Domain.Entities;

namespace Domain.Entities
{
    public class ProductVariant : BaseEntity
    {
        private readonly List<BranchInventory> _branchInventories = [];


        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public string Color { get; set; } = null!;
        public string Size { get; set; } = null!;
        public string SKU { get; set; } = null!;
        public string Barcode { get; set; } = null!;
        public IReadOnlyCollection<BranchInventory> BranchInventories => _branchInventories;
        private ProductVariant() { }

        private ProductVariant(
            Guid productId, string color, string size, string sku, string barcode)
        {
            ProductId = productId;
            SetColor(color);
            SetSize(size);
            SetSku(sku);
            SetBarcode(barcode);
        }

        public static ProductVariant Create(Guid productId, string color, string size, string sku, string barcode)
        {
            return new ProductVariant(productId, color, size, sku, barcode);
        }

        private void SetColor(string color)
        {
            if (string.IsNullOrWhiteSpace(color))
                throw new ArgumentNullException("Color cannot be empty");

            Color = color.Trim();
        }

        private void SetSize(string size)
        {
            if (string.IsNullOrWhiteSpace(size))
                throw new ArgumentNullException("Size cannot be empty");

            Size = size.Trim();
        }

        private void SetSku(string sku)
        {
            if (string.IsNullOrEmpty(sku))
                throw new ArgumentNullException("Sku cannot be empty");

            SKU = sku.Trim();
        }

        private void SetBarcode(string barcode)
        {
            if (string.IsNullOrWhiteSpace(barcode))
                throw new ArgumentNullException("Barcode cannot be empty");

            Barcode = barcode.Trim();
        }
    }
}
