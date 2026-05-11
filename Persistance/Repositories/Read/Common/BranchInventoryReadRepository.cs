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

        public async Task<bool> ExistsAsync(Guid productId, Guid branchId)
        {
            return await Context.BranchInventories
                .AsNoTracking()
                .AnyAsync(x =>x.ProductId == productId &&
                              x.BranchId == branchId &&
                              !x.IsDeleted);
        }

        public async Task<BranchInventory?> GetByProductAndBranchAsync(Guid productId, Guid branchId)
        {
            return await Context.BranchInventories
                .FirstOrDefaultAsync(x =>
                x.ProductId == productId &&
                x.BranchId == branchId &&
                !x.IsDeleted);
        }
    }
}
