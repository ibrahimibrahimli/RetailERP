using Application.Interfaces.Repositories.Read.Common;
using Domain.Entities;
using Persistance.Context;

namespace Persistance.Repositories.Read.Common
{
    public sealed class BonusRuleReadRepository : ReadRepository<BonusRule>, IBonusRuleReadRepository
    {
        public BonusRuleReadRepository(RetailERPDbContext context) : base(context)
        {
        }
    }
}
