using Application.Interfaces.Repositories.Read.Common;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using RetailERP.Domain.Entities;

namespace Persistance.Repositories.Read.Common
{
    public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
    {
        public ProductReadRepository(RetailERPDbContext context) : base(context)
        {
        }

        public async Task<bool> ExistBarcodeAsync(string barcode)
        {
            return await Context.Products
                .AsNoTracking()
                .AnyAsync( x => x.Barcode == barcode &&
                                !x.IsDeleted);
        }
    }
}
