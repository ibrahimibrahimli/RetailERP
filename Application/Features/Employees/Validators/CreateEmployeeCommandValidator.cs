using Application.Features.Employees.Commands.CreateEmployee;
using FluentValidation;

namespace Application.Features.Employees.Validators
{
    public sealed class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeCommandValidator()
        {
            RuleFor(x => x.BranchId)
            .NotEmpty();

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.EmployeeCode)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
