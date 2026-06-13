using Domain.Entities;

namespace Application.Interfaces.Repositories.Read.Common
{
    public interface IEmployeeTransferReadRepository : IReadRepository<EmployeeTransfer>
    {
        Task<List<EmployeeTransfer>> GetByEmployeeAsync(Guid employeeId);
    }
}
