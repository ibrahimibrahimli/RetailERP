using Application.Features.Bonuses.Queries.CalculateBonus;
using FluentValidation;

namespace Application.Features.Bonuses.Validations
{
    public sealed class CalculateBonusQueryValidator : AbstractValidator<CalculateBonusQuery>
    {
        public CalculateBonusQueryValidator()
        {
            RuleFor(x => x.EmployeeId)
           .NotEmpty();

            RuleFor(x => x.Year)
                .InclusiveBetween(2000, 2100);

            RuleFor(x => x.Month)
                .InclusiveBetween(1, 12);
        }
    }
}
