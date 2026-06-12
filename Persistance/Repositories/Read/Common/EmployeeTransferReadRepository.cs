using Application.Interfaces.Repositories.Read.Common;
using Domain.Entities;
using Persistance.Context;

namespace Persistance.Repositories.Read.Common
{
    public sealed class EmployeeTransferReadRepository : ReadRepository<EmployeeTransfer>, IEmployeeTransferReadRepository
    {
        public EmployeeTransferReadRepository(RetailERPDbContext context) : base(context)
        {
        }
    }
}
