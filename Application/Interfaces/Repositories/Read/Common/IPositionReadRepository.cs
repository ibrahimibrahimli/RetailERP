using Domain.Entities;

namespace Application.Interfaces.Repositories.Read.Common
{
    public interface IPositionReadRepository : IReadRepository<Position>
    {
        Task<bool> CheckPositionByNameAsync(string name);
    }
}
