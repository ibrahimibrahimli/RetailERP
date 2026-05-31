using Application.Interfaces.Repositories.Read.Common;
using Domain.Entities;
using Persistance.Context;

namespace Persistance.Repositories.Read.Common
{
    public sealed class EmployeeReadRepository : ReadRepository<Employee>, IEmployeeReadRepository
    {
        public EmployeeReadRepository(RetailERPDbContext context) : base(context)
        {
        }
    }
}
