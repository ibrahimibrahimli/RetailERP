using Application.Interfaces.Repositories.Read.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repositories.Read.Common
{
    public sealed class EmployeeReadRepository : ReadRepository<Employee>, IEmployeeReadRepository
    {
        public EmployeeReadRepository(RetailERPDbContext context) : base(context)
        {
        }

        public async Task<List<Employee>> GetAllByBranch()
        {
            return await Context.Employees
                .AsNoTracking()
                .Include(x => x.Branch)
                .ToListAsync();
        }
    }
}
