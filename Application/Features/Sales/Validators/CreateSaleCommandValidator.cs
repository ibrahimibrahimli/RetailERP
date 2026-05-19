using Application.Features.Sales.Commands.CreateSale;
using FluentValidation;

namespace Application.Features.Sales.Validators
{
    public sealed class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
    {
        public CreateSaleCommandValidator()
        {
            RuleFor(x => x.BranchId)
                .NotEmpty();

            RuleFor(x => x.Items)
                .NotEmpty();

            RuleForEach(x => x.Items)
                .ChildRules(item =>
                {
                    item.RuleFor(x => x.ProductId)
                    .NotEmpty();

                    item.RuleFor(x => x.Quantity)
                    .GreaterThan(0);
                });
        }
    }
}
