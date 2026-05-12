using Application.Features.BranchInventories.Commands.SellProduct;
using FluentValidation;

namespace Application.Features.BranchInventories.Validators
{
    public class SellProductCommandValidator : AbstractValidator<SellProductCommand>
    {
        public SellProductCommandValidator()
        {
            RuleFor(x => x.ProductId)
            .NotEmpty();

            RuleFor(x => x.BranchId)
                .NotEmpty();

            RuleFor(x => x.Quantity)
                .GreaterThan(0);
        }
    }
}
