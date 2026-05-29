using Application.Features.ProductVariants.Commands.CreateProductVariant;
using FluentValidation;

namespace Application.Features.ProductVariants.Validators
{
    public sealed class CreateProductVariantCommandValidator : AbstractValidator<CreateProductVariantCommand>
    {
        public CreateProductVariantCommandValidator()
        {
            RuleFor(x => x.ProductId)
            .NotEmpty();

            RuleFor(x => x.Color)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Size)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.SKU)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Barcode)
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}
