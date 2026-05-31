using Application.Features.BranchInventories.Commands.TransferStock;
using FluentValidation;

namespace Application.Features.BranchInventories.Validators
{
    public class TransferStockCommandValidator : AbstractValidator<TransferStockCommand>
    {
        public TransferStockCommandValidator()
        {
            RuleFor(x => x.ProductVariantId)
           .NotEmpty();

            RuleFor(x => x.FromBranchId)
                .NotEmpty();

            RuleFor(x => x.ToBranchId)
                .NotEmpty();

            RuleFor(x => x.Quantity)
                .GreaterThan(0);

            RuleFor(x => x)
                .Must(x => x.FromBranchId != x.ToBranchId)
                .WithMessage(
                "Source and destination branch cannot be the same.");
        }
    }
}
