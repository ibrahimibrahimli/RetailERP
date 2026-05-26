using Domain.Entities;

namespace Application.Interfaces.Repositories.Read.Common
{
    public interface IBranchInventoryReadRepository : IReadRepository<BranchInventory>
    {
        Task<BranchInventory?> GetByProductAndBranchAsync(Guid productVariantId, Guid branchId);
        Task<bool> ExistsAsync(Guid productVariantId, Guid branchId);
        Task<List<BranchInventory>> GetLowStockInventoriesAsync();
    }
}
