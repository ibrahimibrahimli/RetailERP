using Application.Interfaces.Repositories.Write.Common;
using Domain.Common;
using Persistance.Context;

namespace Persistance.Repositories.Write.Common
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        protected readonly RetailERPDbContext Context;

        public WriteRepository(RetailERPDbContext context)
        {
            Context = context;
        }

        public async Task AddAsync(T entity)
        {
            await Context.Set<T>().AddAsync(entity);
        }

        public void Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await Context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            Context.Set<T>().Update(entity);
        }
    }
}
