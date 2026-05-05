using Application.Interfaces.Repositories.Read.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repositories.Read.Common
{
    public class BranchReadRepository : ReadRepository<Branch>, IBranchReadRepository
    {
        public BranchReadRepository(RetailERPDbContext context) : base(context)
        {
        }

        public async Task<bool> ExistsByNameAsync(Guid brandId, string branchName)
        {
            return await Context.Branches
                .AsNoTracking()
                .AnyAsync(x => x.BrandId == brandId &&
                               x.Name == branchName &&
                               !x.IsDeleted);
        }
    }
}
