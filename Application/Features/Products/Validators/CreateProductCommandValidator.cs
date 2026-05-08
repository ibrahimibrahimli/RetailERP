using FluentValidation;
using RetailERP.Domain.Entities;

namespace Application.Features.Products.Validators
{
    public class CreateProductCommandValidator : AbstractValidator<Product>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(150);

            RuleFor(x => x.Description)
                .NotEmpty()
                .MaximumLength(500);

            RuleFor(x => x.Price)
                .GreaterThan(0);

            RuleFor(x => x.Barcode)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.BrandId)
                .NotEmpty();
        }
    }
}
