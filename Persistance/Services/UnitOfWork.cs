using Application.Interfaces;
using Persistance.Context;

namespace Persistance.Services
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly RetailERPDbContext _context;

        public UnitOfWork(RetailERPDbContext context)
        {
            _context = context;
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
