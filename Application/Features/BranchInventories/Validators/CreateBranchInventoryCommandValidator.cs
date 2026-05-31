using Application.Features.BranchInventories.Commands.CreateBranchInventory;
using FluentValidation;

namespace Application.Features.BranchInventories.Validators
{
    public class CreateBranchInventoryCommandValidator : AbstractValidator<CreateBranchInventoryCommand>
    {
        public CreateBranchInventoryCommandValidator()
        {
            RuleFor(x => x.ProductVariantId)
            .NotEmpty();

            RuleFor(x => x.BranchId)
                .NotEmpty();

            RuleFor(x => x.InitialQuantity)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.MinimumStockLevel)
                .GreaterThanOrEqualTo(0);
        }
    }
}
