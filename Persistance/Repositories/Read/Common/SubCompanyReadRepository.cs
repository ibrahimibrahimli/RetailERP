using Application.Interfaces.Repositories.Read.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repositories.Read.Common
{
    public class SubCompanyReadRepository : ReadRepository<SubCompany>, ISubCompanyReadRepository
    {
        public SubCompanyReadRepository(RetailERPDbContext context) : base(context)
        {
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await Context.SubCompanies
                .AsNoTracking()
                .AnyAsync(x => x.Name == name);
        }
    }
}
