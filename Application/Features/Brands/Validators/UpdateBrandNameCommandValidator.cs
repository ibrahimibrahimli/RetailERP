using Domain.Entities;
using FluentValidation;

namespace Application.Features.Brands.Validators
{
    public class UpdateBrandNameCommandValidator : AbstractValidator<Brand>
    {
        public UpdateBrandNameCommandValidator()
        {
            RuleFor(x => x.Id)
            .NotEmpty();

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}
