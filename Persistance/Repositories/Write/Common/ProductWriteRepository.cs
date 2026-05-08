using Application.Interfaces.Repositories.Write.Common;
using Persistance.Context;
using RetailERP.Domain.Entities;

namespace Persistance.Repositories.Write.Common
{
    public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
    {
        public ProductWriteRepository(RetailERPDbContext context) : base(context)
        {
        }
    }
}
