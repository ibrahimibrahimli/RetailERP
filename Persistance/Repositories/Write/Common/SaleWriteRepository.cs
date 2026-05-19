using Application.Interfaces.Repositories.Write.Common;
using Domain.Entities;
using Persistance.Context;

namespace Persistance.Repositories.Write.Common
{
    public sealed class SaleWriteRepository : WriteRepository<Sale>, ISaleWriteRepository
    {
        public SaleWriteRepository(RetailERPDbContext context) : base(context)
        {
        }
    }
}
