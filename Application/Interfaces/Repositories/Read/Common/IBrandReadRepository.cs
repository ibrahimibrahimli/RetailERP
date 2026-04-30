using Domain.Entities;

namespace Application.Interfaces.Repositories.Read.Common
{
    public interface IBrandReadRepository : IReadRepository<Brand>
    {
        Task<bool> ExistsByNameAsync(string name);
        Task<List<Brand>> GetAllWithSubCompanyAsync();
    }
}
