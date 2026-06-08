using Application.Features.Sales.DTOs;
using Domain.Entities;

namespace Application.Interfaces.Repositories.Read.Common
{
    public interface ISaleReadRepository : IReadRepository<Sale>
    {
        Task<Sale?> GetSaleDetailAsync(Guid saleId);
        Task<List<Sale>> GetAllSalesAsync();
        Task<List<Sale>> GetSalesByBranchAsync(Guid branchId);
        Task<List<Sale>> GetSalesByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<List<Sale>> GetByEmployeeAsync(Guid employeeId);
        Task<List<TopSellingProductDto>> GetTopSellingProductAsync(int count);
        Task<List<Sale>> GetRevenueByBranchAsync(int count);
        Task<List<Sale>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
    }
}
