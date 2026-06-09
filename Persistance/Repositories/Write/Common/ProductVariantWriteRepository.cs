using Application.Interfaces.Repositories.Write.Common;
using Domain.Entities;
using Persistance.Context;

namespace Persistance.Repositories.Write.Common
{
    public class ProductVariantWriteRepository : WriteRepository<ProductVariant>, IProductVariantWriteRepository
    {
        public ProductVariantWriteRepository(RetailERPDbContext context) : base(context)
        {
        }
    }
}
