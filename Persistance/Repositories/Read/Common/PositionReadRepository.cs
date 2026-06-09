using Application.Interfaces.Repositories.Read.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repositories.Read.Common
{
    public sealed class PositionReadRepository : ReadRepository<Position>, IPositionReadRepository
    {
        public PositionReadRepository(RetailERPDbContext context) : base(context)
        {
        }

        public async Task<bool> CheckPositionByNameAsync(string name)
        {
            return await Context.Positions
                .AsNoTracking()
                .AnyAsync(x => x.Name == name);
        }
    }
}
