using Domain.Entities;

namespace Application.Interfaces.Repositories.Read.Common
{
    public interface IBranchInventoryReadRepository : IReadRepository<BranchInventory>
    {
        Task<BranchInventory?> GetByProductAndBranchAsync(Guid productId, Guid branchId);
        Task<bool> ExistsAsync(Guid productId, Guid branchId);
    }
}
