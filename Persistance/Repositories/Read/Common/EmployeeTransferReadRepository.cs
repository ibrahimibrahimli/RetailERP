using Application.Interfaces.Repositories.Read.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repositories.Read.Common
{
    public sealed class EmployeeTransferReadRepository : ReadRepository<EmployeeTransfer>, IEmployeeTransferReadRepository
    {
        public EmployeeTransferReadRepository(RetailERPDbContext context) : base(context)
        {
        }

        public async Task<List<EmployeeTransfer>> GetByEmployeeAsync(Guid employeeId)
        {
            return await Context.EmployeeTransfers
                .AsNoTracking()
                .Where(x => x.EmployeeId == employeeId&&
                !x.IsDeleted)
                .ToListAsync();

        }
    }
}
