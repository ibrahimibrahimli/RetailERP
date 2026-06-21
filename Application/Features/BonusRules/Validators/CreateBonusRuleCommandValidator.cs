using Application.Features.BonusRules.Commands;
using FluentValidation;

namespace Application.Features.BonusRules.Validators
{
    public sealed class CreateBonusRuleCommandValidator : AbstractValidator<CreateBonusRuleCommand>
    {
        public CreateBonusRuleCommandValidator()
        {
            RuleFor(x => x.PositionId)
           .NotEmpty();

            RuleFor(x => x.MinimumSales)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.BonusValue)
                .GreaterThan(0);

            RuleFor(x => x.EffectiveFrom)
                .NotEmpty();

            RuleFor(x => x)
                .Must(x =>
                    !x.MaximumSales.HasValue ||
                    x.MaximumSales >= x.MinimumSales)
                .WithMessage("Maximum sales must be greater than or equal to minimum sales");
        }
    }
}
