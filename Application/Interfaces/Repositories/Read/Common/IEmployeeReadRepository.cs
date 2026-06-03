using Domain.Entities;

namespace Application.Interfaces.Repositories.Read.Common
{
    public interface IEmployeeReadRepository : IReadRepository<Employee>
    {
        Task<List<Employee>> GetAllByBranch();
    }
}
