using RetailERP.Domain.Entities;

namespace Application.Interfaces.Repositories.Read.Common
{
    public interface IProductReadRepository : IReadRepository<Product>
    {
        Task<bool> ExistBarcodeAsync(string barcode);
    }
}
