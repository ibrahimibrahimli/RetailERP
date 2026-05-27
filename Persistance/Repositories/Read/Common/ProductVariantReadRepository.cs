using Application.Interfaces.Repositories.Read.Common;
using Domain.Entities;
using Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories.Read.Common
{
    public sealed class ProductVariantReadRepository : ReadRepository<ProductVariant>, IProductVariantReadRepository
    {
        public ProductVariantReadRepository(RetailERPDbContext context) : base(context)
        {
        }

        public override async Task<ProductVariant?> GetByIdAsync(Guid id)
        {
            return await Context.Set<ProductVariant>()
            .Include(x => x.Product)
            .FirstOrDefaultAsync(x =>
            x.Id == id &&
            !x.IsDeleted);
        }
    }
}
