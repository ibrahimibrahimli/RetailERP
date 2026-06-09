using Application.Interfaces.Repositories.Write.Common;
using Domain.Entities;
using Persistance.Context;

namespace Persistance.Repositories.Write.Common
{
    public sealed class PositionWriteRepository : WriteRepository<Position>, IPositionWriteRepository
    {
        public PositionWriteRepository(RetailERPDbContext context) : base(context)
        {
        }
    }
}
