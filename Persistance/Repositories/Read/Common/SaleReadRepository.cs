using Application.Features.Sales.DTOs;
using Application.Interfaces.Repositories.Read.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repositories.Read.Common
{
    public class SaleReadRepository : ReadRepository<Sale>, ISaleReadRepository
    {
        public SaleReadRepository(RetailERPDbContext context) : base(context)
        {
        }

        public async Task<List<Sale>> GetAllSalesAsync()
        {
            return await Context.Sales
                .AsNoTracking()
                .OrderByDescending(x => x.SaleDate)
                .ToListAsync();
        }

        public async Task<List<Sale>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await Context.Sales
                .AsNoTracking()
                .Where(x =>
                       !x.IsDeleted&&
                       x.CreatedAt >= startDate &&
                       x.CreatedAt <= endDate)
                .ToListAsync();
        }

        public async Task<List<Sale>> GetByEmployeeAsync(Guid employeeId)
        {
            return await Context.Sales
                .AsNoTracking()
                .Include(x => x.Items)
                .Where(x => x.EmployeeId == employeeId && !x.IsDeleted)
                .OrderByDescending(x => x.SaleDate)
                .ToListAsync();
        }

        public async Task<List<Sale>> GetRevenueByBranchAsync(int count)
        {
            return await Context.Sales
                .AsNoTracking()
                .Include(x => x.Branch)
                .Where(x => !x.IsDeleted)
                .ToListAsync();
        }

        public async Task<Sale?> GetSaleDetailAsync(Guid saleId)
        {
            return await Context.Sales
                .AsNoTracking()
                .Include(x => x.Items)
                .FirstOrDefaultAsync(x => x.Id == saleId && !x.IsDeleted);
        }

        public async Task<List<Sale>> GetSalesByBranchAsync(Guid branchId)
        {
            return await Context.Sales
                .AsNoTracking()
                .Where(x => x.BranchId == branchId && !x.IsDeleted)
                .OrderByDescending(x => x.SaleDate)
                .ToListAsync();
        }

        public async Task<List<Sale>> GetSalesByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await Context.Sales
                .AsNoTracking()
                .Where(x => x.SaleDate >= startDate && x.SaleDate <= endDate && !x.IsDeleted)
                .OrderByDescending(x => x.SaleDate)
                .ToListAsync();
        }

        public async Task<List<TopSellingProductDto>> GetTopSellingProductAsync(int count)
        {
            var data = await Context.SaleItems
                  .AsNoTracking()
                  .Where(x => !x.IsDeleted)
                  .GroupBy(x => new
                  {
                      x.ProductVariantId,
                      x.ProductName,
                      x.Color,
                      x.Size,
                      x.SKU
                  })
                  .Select(x => new
                  {
                      x.Key.ProductVariantId,
                      x.Key.ProductName,
                      x.Key.Color,
                      x.Key.Size,
                      x.Key.SKU,
                      QuantitySold = x.Sum(i => i.Quantity),
                      Revenue = x.Sum(i => i.TotalPrice)
                  })
                  .OrderByDescending(x => x.QuantitySold)
                  .Take(count)
                  .ToListAsync();
                  
                         return data.Select(x =>
                             new TopSellingProductDto(
                                 x.ProductVariantId,
                                 x.ProductName,
                                 x.Color,
                                 x.Size,
                                 x.SKU,
                                 x.QuantitySold,
                                 x.Revenue))
                             .ToList();
        }
    }
}
