using Domain.Common;
using Domain.Entities;

namespace RetailERP.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; private set; }

    public string Description { get; private set; }

    public decimal Price { get; private set; }

    public string Barcode { get; private set; }

    public bool IsActive { get; private set; }

    public Guid BrandId { get; private set; }

    public Brand Brand { get; private set; } = null!;

    private readonly List<BranchInventory> _branchInventories = [];
    public IReadOnlyCollection<BranchInventory> BranchInventories => _branchInventories.AsReadOnly();

    private Product()
    {
    }

    private Product(
        string name,
        string description,
        decimal price,
        string barcode,
        Guid brandId)
    {
        SetName(name);

        SetDescription(description);

        SetPrice(price);

        SetBarcode(barcode);

        BrandId = brandId;

        IsActive = true;
    }

    public static Product Create(
        string name,
        string description,
        decimal price,
        string barcode,
        Guid brandId)
    {
        return new Product(
            name,
            description,
            price,
            barcode,
            brandId);
    }

    public void Activate()
    {
        IsActive = true;

        SetUpdatedTime();
    }

    public void Deactivate()
    {
        IsActive = false;

        SetUpdatedTime();
    }

    public void UpdateName(string name)
    {
        SetName(name);

        SetUpdatedTime();
    }

    public void UpdateDescription(string description)
    {
        SetDescription(description);

        SetUpdatedTime();
    }

    public void UpdatePrice(decimal price)
    {
        SetPrice(price);

        SetUpdatedTime();
    }

    public void Delete()
    {
        MarkAsDeleted();

        SetUpdatedTime();
    }

    private void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException(
                "Product name cannot be empty.");
        }

        Name = name.Trim();
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

    private void SetPrice(decimal price)
    {
        if (price <= 0)
        {
            throw new ArgumentException(
                "Price must be greater than zero.");
        }

        Price = price;
    }

    private void SetBarcode(string barcode)
    {
        if (string.IsNullOrWhiteSpace(barcode))
        {
            throw new ArgumentException(
                "Barcode cannot be empty.");
        }

        Barcode = barcode.Trim();
    }
}