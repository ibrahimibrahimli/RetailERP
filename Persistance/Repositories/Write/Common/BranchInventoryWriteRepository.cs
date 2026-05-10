using Application.Interfaces.Repositories.Write.Common;
using Domain.Entities;
using Persistance.Context;

namespace Persistance.Repositories.Write.Common
{
    public class BranchInventoryWriteRepository : WriteRepository<BranchInventory>, IBranchInventoryWriteRepository
    {
        public BranchInventoryWriteRepository(RetailERPDbContext context) : base(context)
        {
        }
    }
}
