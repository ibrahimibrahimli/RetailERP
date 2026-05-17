using Domain.Entities;

namespace Application.Interfaces.Repositories.Read.Common
{
    public interface IInventoryTransactionReadRepository : IReadRepository<InventoryTransaction>
    {
        Task<List<InventoryTransaction>> GetByBranchInventoryIdAsync(Guid branchInventoryId);
    }
}
