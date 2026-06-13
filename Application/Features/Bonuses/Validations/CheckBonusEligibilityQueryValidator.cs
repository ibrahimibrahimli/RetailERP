using Application.Features.Bonuses.Queries;
using FluentValidation;

namespace Application.Features.Bonuses.Validations
{
    public sealed class CheckBonusEligibilityQueryValidator : AbstractValidator<CheckBonusEligibilityQuery>
    {
        public CheckBonusEligibilityQueryValidator()
        {
            RuleFor(x => x.EmployeeId).NotEmpty();

            RuleFor(x => x.Month).InclusiveBetween(1, 12);

            RuleFor(x => x.Year).GreaterThanOrEqualTo(2000);
        }
    }
}
