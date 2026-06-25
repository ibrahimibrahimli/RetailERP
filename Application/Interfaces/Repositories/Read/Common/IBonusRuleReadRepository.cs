using Application.Features.BonusRules.DTOs;
using Domain.Entities;
using Domain.Enums;

namespace Application.Interfaces.Repositories.Read.Common
{
    public interface IBonusRuleReadRepository : IReadRepository<BonusRule>
    {
        Task<bool> HasOverlappingRuleAsync(Guid positionId,
            BonusType bonusType,
            DateOnly effectiveFrom,
            DateOnly? effectiveTo,
            CancellationToken cancellationToken = default);

        Task<List<BonusRuleDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<BonusRule?> GetByIdAsync(Guid Id,  CancellationToken cancellationToken = default); 
    }
}
