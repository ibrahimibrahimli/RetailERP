using Domain.Common;

namespace Application.Interfaces.Repositories.Read.Common
{
    public interface IReadRepository<T> where T : BaseEntity
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<T?> GetTrackedByIdAsync(Guid id);
        Task<List<T>> GetAllAsync();
    }
}
