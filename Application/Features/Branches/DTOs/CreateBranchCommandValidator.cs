using Domain.Entities;
using FluentValidation;

namespace Application.Features.Branches.DTOs
{
    public class CreateBranchCommandValidator : AbstractValidator<Branch>
    {
        public CreateBranchCommandValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);

            RuleFor(x => x.Address)
                .NotEmpty()
                .MaximumLength(250);

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .MaximumLength(20);

            RuleFor(x => x.BrandId)
                .NotEmpty();
        }
    }
}
