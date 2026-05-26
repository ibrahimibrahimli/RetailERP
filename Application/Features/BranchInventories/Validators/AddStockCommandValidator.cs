using Domain.Entities;
using FluentValidation;

namespace Application.Features.BranchInventories.Validators
{
    public class AddStockCommandValidator : AbstractValidator<BranchInventory>
    {
        public AddStockCommandValidator()
        {
            RuleFor(x => x.ProductVariantId)
            .NotEmpty();

            RuleFor(x => x.BranchId)
                .NotEmpty();

            RuleFor(x => x.Quantity)
                .GreaterThan(0);
        }
    }
}
