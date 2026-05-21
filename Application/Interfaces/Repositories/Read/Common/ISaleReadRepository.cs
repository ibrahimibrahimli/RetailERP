using Domain.Entities;

namespace Application.Interfaces.Repositories.Read.Common
{
    public interface ISaleReadRepository : IReadRepository<Sale>
    {
        Task<Sale?> GetSaleDetailAsync(Guid saleId);
        Task<List<Sale>> GetAllSalesAsync();
    }
}
