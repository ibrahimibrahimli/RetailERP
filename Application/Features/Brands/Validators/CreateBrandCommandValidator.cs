using Application.Features.Brands.Command.CreateBrand;
using FluentValidation;

namespace Application.Features.Brands.Validators
{
    public class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommand>
    {
        public CreateBrandCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.SubCompanyId)
                .NotEmpty();
        }
    }
}
