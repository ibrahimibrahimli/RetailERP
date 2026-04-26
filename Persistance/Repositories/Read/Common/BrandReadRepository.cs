using Application.Interfaces.Repositories.Read.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repositories.Read.Common
{
    public class BrandReadRepository : ReadRepository<Brand>, IBrandReadRepository
    {

        public BrandReadRepository(RetailERPDbContext context) : base(context)
        {
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await Context.Brands
                .AsNoTracking()
                .AnyAsync(x => x.Name == name);
        }
    }
}
