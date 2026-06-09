using Application.Common.Results;
using MediatR;

namespace Application.Features.Positions.Command.CreatePosition
{
    public sealed record CreatePositionCommand(string Name) : IRequest<Result<Guid>>;
}
