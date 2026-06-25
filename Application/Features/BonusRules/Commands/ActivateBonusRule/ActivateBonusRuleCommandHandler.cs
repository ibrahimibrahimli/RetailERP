using Application.Common.Results;
using Application.Interfaces;
using Application.Interfaces.Repositories.Read.Common;
using MediatR;

namespace Application.Features.BonusRules.Commands.ActivateBonusRule
{
    public sealed class ActivateBonusRuleCommandHandler : IRequestHandler<ActivateBonusRuleCommand, Result>
    {
        private readonly IBonusRuleReadRepository _readRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ActivateBonusRuleCommandHandler(IBonusRuleReadRepository readRepository, IUnitOfWork unitOfWork)
        {
            _readRepository = readRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(ActivateBonusRuleCommand request, CancellationToken cancellationToken)
        {
            var rule = await _readRepository.GetByIdAsync(request.Id);
            if (rule is null)
                return Result.Failure("Rule not found");

            rule.Activate();

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
