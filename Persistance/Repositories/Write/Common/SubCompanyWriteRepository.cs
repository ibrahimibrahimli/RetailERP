using Application.Interfaces.Repositories.Write.Common;
using Domain.Entities;
using Persistance.Context;

namespace Persistance.Repositories.Write.Common
{
    public class SubCompanyWriteRepository : WriteRepository<SubCompany>, ISubCompanyWriteRepository
    {
        public SubCompanyWriteRepository(RetailERPDbContext context) : base(context)
        {
        }
    }
}
