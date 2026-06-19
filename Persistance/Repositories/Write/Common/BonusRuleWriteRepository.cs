using Application.Interfaces.Repositories.Write.Common;
using Domain.Entities;
using Persistance.Context;

namespace Persistance.Repositories.Write.Common
{
    public sealed class BonusRuleWriteRepository : WriteRepository<BonusRule>, IBonusRuleWriteRepository
    {
        public BonusRuleWriteRepository(RetailERPDbContext context) : base(context)
        {
        }
    }
}
