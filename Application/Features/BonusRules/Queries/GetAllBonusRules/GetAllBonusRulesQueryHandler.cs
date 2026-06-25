using Application.Common.Results;
using Application.Features.BonusRules.DTOs;
using Application.Interfaces.Repositories.Read.Common;
using MediatR;

namespace Application.Features.BonusRules.Queries.GetAllBonusRules
{
    public sealed class GetAllBonusRulesQueryHandler : IRequestHandler<GetAllBonusRulesQuery, Result<List<BonusRuleDto>>>
    {
        private readonly IBonusRuleReadRepository _readRepository;

        public GetAllBonusRulesQueryHandler(IBonusRuleReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<Result<List<BonusRuleDto>>> Handle(GetAllBonusRulesQuery request, CancellationToken cancellationToken)
        {
            var result = await _readRepository.GetAllAsync(cancellationToken);
            if (result is null)
                return Result<List<BonusRuleDto>>.Failure("Bonus rules not found");

            return Result<List<BonusRuleDto>>.Success(result);
        }
    }
}
