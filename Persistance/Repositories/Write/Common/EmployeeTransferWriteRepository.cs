using Application.Interfaces.Repositories.Write.Common;
using Domain.Entities;
using Persistance.Context;

namespace Persistance.Repositories.Write.Common
{
    public sealed class EmployeeTransferWriteRepository : WriteRepository<EmployeeTransfer>, IEmployeeTransferWriteRepository
    {
        public EmployeeTransferWriteRepository(RetailERPDbContext context) : base(context)
        {
        }
    }
}
