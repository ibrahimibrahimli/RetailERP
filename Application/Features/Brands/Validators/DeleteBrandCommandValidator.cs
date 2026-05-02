using Domain.Entities;
using FluentValidation;

namespace Application.Features.Brands.Validators
{
    public class DeleteBrandCommandValidator : AbstractValidator<Brand>
    {
        public DeleteBrandCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
