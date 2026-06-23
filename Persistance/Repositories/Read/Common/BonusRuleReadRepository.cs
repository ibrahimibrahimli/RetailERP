using Application.Features.BonusRules.DTOs;
using Application.Interfaces.Repositories.Read.Common;
using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repositories.Read.Common
{
    public sealed class BonusRuleReadRepository : ReadRepository<BonusRule>, IBonusRuleReadRepository
    {
        public BonusRuleReadRepository(RetailERPDbContext context) : base(context)
        {
        }

        public async Task<List<BonusRuleDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await Context.BonusRules
                .AsNoTracking()
                .Where(x => !x.IsDeleted)
                .Include(x => x.Position)
                .OrderBy(x => x.Position.Name)
                .ThenBy(x => x.MinimumSales)
                .Select(x => new BonusRuleDto (
                    x.Id,
                    x.PositionId,
                    x.Position.Name,
                    x.BonusType,
                    x.MinimumSales,
                    x.MaximumSales,
                    x.BonusValue,
                    x.EffectiveFrom,
                    x.EffectiveTo,
                    x.IsActive)).ToListAsync(cancellationToken);
        }

        public async Task<bool> HasOverlappingRuleAsync(Guid positionId, BonusType bonusType, DateOnly effectiveFrom, DateOnly? effectiveTo, CancellationToken cancellationToken = default)
        {
            var newEffectiveTo = effectiveTo ?? DateOnly.MaxValue;

            return await Context.BonusRules
                .AsNoTracking()
                .Where(x => !x.IsDeleted)
                .Where(x => x.IsActive)
                .Where(x => x.PositionId == positionId)
                .Where(x => x.BonusType == bonusType)
                .AnyAsync(x =>
                    effectiveFrom <= (x.EffectiveTo ?? DateOnly.MaxValue) &&
                    newEffectiveTo >= x.EffectiveFrom,
                    cancellationToken);
        }
    }
}
