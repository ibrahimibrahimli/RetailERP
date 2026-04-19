using Application.Interfaces.Repositories.Read.Common;
using Domain.Entities;
using Persistance.Context;

namespace Persistance.Repositories.Read.Common
{
    public class BrandReadRepository : ReadRepository<Brand>, IBrandReadRepository
    {
        public BrandReadRepository(RetailERPDbContext context) : base(context)
        {
        }
    }
}
