using Domain.Entities;

namespace Application.Interfaces.Repositories.Read.Common
{
    public interface IBranchReadRepository : IReadRepository<Branch>
    {
        Task<bool> ExistsByNameAsync(Guid brandId, string branchName);
    }
}
