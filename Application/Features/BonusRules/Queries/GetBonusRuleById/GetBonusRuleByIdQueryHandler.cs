using Application.Common.Results;
using Application.Features.BonusRules.DTOs;
using Application.Interfaces.Repositories.Read.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.BonusRules.Queries.GetBonusRuleById
{
    public sealed class GetBonusRuleByIdQueryHandler : IRequestHandler<GetBonusRuleByIdQuery, Result<BonusRule>>
    {
        private readonly IBonusRuleReadRepository _readRepository;

        public GetBonusRuleByIdQueryHandler(IBonusRuleReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<Result<BonusRule>> Handle(GetBonusRuleByIdQuery request, CancellationToken cancellationToken)
        {
            var rule = await _readRepository.GetByIdAsync(request.Id, cancellationToken);
            if (rule is null)
                return Result<BonusRule>.Failure("Rule not found");

            return Result<BonusRule>.Success(rule);
        }
    }
}
