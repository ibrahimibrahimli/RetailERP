using Domain.Entities;
using FluentValidation;

namespace Application.Features.SubCompanies.Validators
{
    public class CreateSubCompanyCommandValidator : AbstractValidator<SubCompany>
    {
        public CreateSubCompanyCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}
