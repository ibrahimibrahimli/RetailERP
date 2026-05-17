using Application.Interfaces.Repositories.Write.Common;
using Domain.Entities;
using Persistance.Context;

namespace Persistance.Repositories.Write.Common
{
    public class InventoryTransactionWriteRepository : WriteRepository<InventoryTransaction>, IInventoryTransactionWriteRepository
    {
        public InventoryTransactionWriteRepository(RetailERPDbContext context) : base(context)
        {
        }
    }
}
