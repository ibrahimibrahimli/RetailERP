using Application.Interfaces.Repositories.Read.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repositories.Read.Common
{
    public class BranchInventoryReadRepository : ReadRepository<BranchInventory>, IBranchInventoryReadRepository
    {
        public BranchInventoryReadRepository(RetailERPDbContext context) : base(context)
        {
        }

        public async Task<bool> ExistsAsync(Guid productVariantId, Guid branchId)
        {
            return await Context.BranchInventories
                .AsNoTracking()
                .AnyAsync(x =>x.ProductVariantId == productVariantId &&
                              x.BranchId == branchId &&
                              !x.IsDeleted);
        }

        public async Task<BranchInventory?> GetByProductAndBranchAsync(Guid productVariantId, Guid branchId)
        {
            return await Context.BranchInventories
                .Include(x => x.Transactions)
                .FirstOrDefaultAsync(x =>
                x.ProductVariantId == productVariantId &&
                x.BranchId == branchId &&
                !x.IsDeleted);
        }

        public async Task<List<BranchInventory>> GetLowStockInventoriesAsync()
        {
            return await Context.BranchInventories
                .AsNoTracking()
                .Include(x => x.ProductVariant)
                .ThenInclude(x => x.Product)
                .Include(x => x.Branch)
                .Where(x => x.Quantity <= x.MinimumStockLevel)
                .ToListAsync();
        }
    }
}
