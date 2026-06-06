using Application.Features.Employees.DTOs;
using Domain.Entities;

namespace Application.Interfaces.Repositories.Read.Common
{
    public interface IEmployeeReadRepository : IReadRepository<Employee>
    {
        Task<List<Employee>> GetAllByBranchAsync();
        Task<List<TopEmployeeDto>> GetTopEmployeesAsync(int count);
    }
}
