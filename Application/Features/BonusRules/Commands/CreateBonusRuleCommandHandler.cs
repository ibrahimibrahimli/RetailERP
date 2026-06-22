using Application.Common.Results;
using Application.Interfaces;
using Application.Interfaces.Repositories.Read.Common;
using Application.Interfaces.Repositories.Write.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.BonusRules.Commands
{
    public sealed class CreateBonusRuleCommandHandler : IRequestHandler<CreateBonusRuleCommand, Result>
    {
        private readonly IBonusRuleReadRepository _bonusRuleReadRepository;
        private readonly IPositionReadRepository _positionReadRepository;
        private readonly IBonusRuleWriteRepository _bonusRuleWriteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateBonusRuleCommandHandler(IBonusRuleReadRepository bonusRuleReadRepository, IPositionReadRepository positionReadRepository, IBonusRuleWriteRepository bonusRuleWriteRepository, IUnitOfWork unitOfWork)
        {
            _bonusRuleReadRepository = bonusRuleReadRepository;
            _positionReadRepository = positionReadRepository;
            _bonusRuleWriteRepository = bonusRuleWriteRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CreateBonusRuleCommand request, CancellationToken cancellationToken)
        {
            var position = await _positionReadRepository.GetByIdAsync(request.PositionId);
            if (position == null)
                return Result.Failure("Position not foind");


            var hasOverlappingRule = await _bonusRuleReadRepository.HasOverlappingRuleAsync(request.PositionId,
                request.BonusType,
                request.EffectiveFrom,
                request.EffectiveTo,
                cancellationToken);
            if (hasOverlappingRule)
                return Result.Failure("An overlapping bonus rule already exists for the selected position and bonus type");


            var bonusRule = BonusRule.Create(
                request.BonusType,
                request.PositionId,
                request.MinimumSales,
                request.MaximumSales,
                request.BonusValue,
                request.EffectiveFrom,
                request.EffectiveTo); 

            await _bonusRuleWriteRepository.AddAsync(bonusRule);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success();    
        }
    }
}
