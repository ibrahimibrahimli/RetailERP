using Application.Features.Positions.Command.CreatePosition;
using FluentValidation;

namespace Application.Features.Positions.Validators
{
    public sealed class CreatePositionCommandValidator : AbstractValidator<CreatePositionCommand>
    {
        public CreatePositionCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(200);
        }
    }
}
