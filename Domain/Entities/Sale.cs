using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class Sale : BaseEntity
    {
        private readonly List<SaleItem> _items = [];
        public IReadOnlyCollection<SaleItem> Items => _items.AsReadOnly();

        public Guid EmployeeId { get; private set; }
        public Employee Employee { get; private set; } = null!;
        public Guid BranchId { get; private set; }
        public Branch Branch { get; private set; } = null!;
        public string InvoiceNumber { get; private set; } = null!;
        public decimal TotalAmount { get; private set; }
        public PaymentMethod PaymentMethod { get; private set; }
        public DateTime SaleDate { get; private set; }

        private Sale() { }

        private Sale(Guid branchId, Guid employeeId, string invoiceNumber, PaymentMethod paymentMethod)
        {
            BranchId = branchId;
            EmployeeId = employeeId;
            InvoiceNumber = invoiceNumber;
            PaymentMethod = paymentMethod;
            SaleDate = DateTime.UtcNow;
        }

        public static Sale Create(Guid branchId, Guid employeeId, string InvoiceNumber, PaymentMethod paymentMethod)
        {
            return new Sale(branchId, employeeId, InvoiceNumber, paymentMethod);
        }

        public void AddItem(Guid productVariantId, string productName, string color, string size, string sku, decimal unitPrice, int quantity)
        {
            SaleItem item = SaleItem.Create(
                productVariantId,
                productName,
                color,
                size,
                sku,
                unitPrice,
                quantity);

            _items.Add(item);

            CalculateTotalAmount();
            SetUpdatedTime();
        }

        private void CalculateTotalAmount()
        {
            TotalAmount = _items.Sum(x => x.TotalPrice);
        }
    }
}
