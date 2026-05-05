using Application.Interfaces.Repositories.Write.Common;
using Domain.Entities;
using Persistance.Context;

namespace Persistance.Repositories.Write.Common
{
    public class BranchWriteRepository : WriteRepository<Branch>, IBranchWriteRepository
    {
        public BranchWriteRepository(RetailERPDbContext context) : base(context)
        {
        }
    }
}
