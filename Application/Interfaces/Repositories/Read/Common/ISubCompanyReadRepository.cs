using Domain.Entities;

namespace Application.Interfaces.Repositories.Read.Common
{
    public interface ISubCompanyReadRepository : IReadRepository<SubCompany>
    {
        Task<bool> ExistsByNameAsync(string name);  
    }
}
