using Application.Common.Results;
using Application.Interfaces;
using Application.Interfaces.Repositories.Read.Common;
using MediatR;

namespace Application.Features.BonusRules.Commands.DeactivateBonusRule
{
    public sealed class DeactivateBonusRuleCommandHandler : IRequestHandler<DeactivateBonusRuleCommand, Result>
    {
        private readonly IBonusRuleReadRepository _readRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeactivateBonusRuleCommandHandler(IBonusRuleReadRepository readRepository, IUnitOfWork unitOfWork)
        {
            _readRepository = readRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(DeactivateBonusRuleCommand request, CancellationToken cancellationToken)
        {
            var rule = await _readRepository.GetByIdAsync(request.Id, cancellationToken);
            if (rule == null)
                return Result.Failure("Rule not found");

            rule.Deactivate();

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
