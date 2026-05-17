using Application.Interfaces.Repositories.Write.Common;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
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

        public void Attach(T entity)
        {
            if (Context.Entry(entity).State == EntityState.Detached)
                Context.Set<T>().Attach(entity);
        }

        public void Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            bool saved = false;
            while (!saved)
            {
                try
                {
                    await Context.SaveChangesAsync();
                    saved = true;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    foreach (var entry in ex.Entries)
                    {
                        var dbValues = await entry.GetDatabaseValuesAsync();

                        if (dbValues == null)
                        {
                            entry.State = EntityState.Detached;
                            continue; 
                        }

                        entry.OriginalValues.SetValues(dbValues);
                        entry.CurrentValues.SetValues(dbValues); 
                    }
                }
            }
        }

        public void Update(T entity)
        {
            Context.Set<T>().Update(entity);
        }
    }
}
