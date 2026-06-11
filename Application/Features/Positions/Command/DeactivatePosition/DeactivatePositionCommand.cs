using Application.Common.Results;
using MediatR;

namespace Application.Features.Positions.Command.DeactivatePosition
{
    public sealed record DeactivatePositionCommand(Guid PositionId) : IRequest<Result>;
}
