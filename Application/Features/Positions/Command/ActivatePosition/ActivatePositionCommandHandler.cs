using Application.Common.Results;
using Application.Interfaces.Repositories.Read.Common;
using Application.Interfaces.Repositories.Write.Common;
using MediatR;

namespace Application.Features.Positions.Command.ActivatePosition
{
    public sealed class ActivatePositionCommandHandler : IRequestHandler<ActivatePositionCommand, Result>
    {
        private readonly IPositionReadRepository _positionReadRepository;
        private readonly IPositionWriteRepository _positionWriteRepository;
        public ActivatePositionCommandHandler(IPositionReadRepository positionReadRepository, IPositionWriteRepository positionWriteRepository)
        {
            _positionReadRepository = positionReadRepository;
            _positionWriteRepository = positionWriteRepository;
        }

        public async Task<Result> Handle(ActivatePositionCommand request, CancellationToken cancellationToken)
        {
            var position = await _positionReadRepository.GetByIdAsync(request.PositionId);
            if (position is null)
                return Result.Failure("Position not found");

            position.Activate();

            await _positionWriteRepository.SaveChangesAsync();

            return Result.Success();
        }
    }
}
