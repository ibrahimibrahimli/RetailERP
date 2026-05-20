using Application.Interfaces.Repositories.Read.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repositories.Read.Common
{
    public class SaleReadRepository : ReadRepository<Sale>, ISaleReadRepository
    {
        public SaleReadRepository(RetailERPDbContext context) : base(context)
        {
        }

        public async Task<Sale?> GetSaleDetailAsync(Guid saleId)
        {
            return await Context.Sales
                .AsNoTracking()
                .Include(x => x.Items)
                .FirstOrDefaultAsync(x => x.Id == saleId && !x.IsDeleted);
        }
    }
}
