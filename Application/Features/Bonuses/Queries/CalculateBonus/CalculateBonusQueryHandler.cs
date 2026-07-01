using Application.Common.Results;
using Application.Features.Bonuses.DTOs;
using MediatR;

namespace Application.Features.Bonuses.Queries.CalculateBonus
{
    public class CalculateBonusQueryHandler : IRequestHandler<CalculateBonusQuery, Result<BonusCalculationResult    >
    {
        public Task<Result<BonusCalculationResult>> Handle(CalculateBonusQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
