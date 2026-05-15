using Application.Interfaces.Repositories.Read.Common;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repositories.Read.Common
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        protected readonly RetailERPDbContext Context;

        public ReadRepository(RetailERPDbContext context)
        {
            Context = context;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await Context.Set<T>()
            .AsNoTracking()
            .ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await Context.Set<T>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<T?> GetTrackedByIdAsync(Guid id)
        {
            return await Context.Set<T>()
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
