using Application.Interfaces.Repositories.Read.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repositories.Read.Common
{
    public sealed class InventoryTransactionReadRepository : ReadRepository<InventoryTransaction>, IInventoryTransactionReadRepository
    {
        public InventoryTransactionReadRepository(RetailERPDbContext context) : base(context)
        {
        }

        public async Task<List<InventoryTransaction>> GetByBranchInventoryIdAsync(Guid branchInventoryId)
        {
            return await Context.InventoryTransactions
                .AsNoTracking()
                .Where(x => x.BranchInventoryId == branchInventoryId &&
                           !x.IsDeleted)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }
    }
}
