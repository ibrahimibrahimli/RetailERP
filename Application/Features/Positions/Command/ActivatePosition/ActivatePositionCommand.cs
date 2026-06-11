using Application.Common.Results;
using MediatR;

namespace Application.Features.Positions.Command.ActivatePosition
{
    public sealed record class ActivatePositionCommand(Guid PositionId) : IRequest<Result>;
}
