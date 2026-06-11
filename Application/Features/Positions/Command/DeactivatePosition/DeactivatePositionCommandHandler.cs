using Application.Common.Results;
using Application.Interfaces.Repositories.Read.Common;
using Application.Interfaces.Repositories.Write.Common;
using MediatR;

namespace Application.Features.Positions.Command.DeactivatePosition
{
    public sealed class DeactivatePositionCommandHandler : IRequestHandler<DeactivatePositionCommand, Result>
    {
        private readonly IPositionReadRepository _positionReadRepository;
        private readonly IPositionWriteRepository _positionWriteRepository;
        public DeactivatePositionCommandHandler(IPositionReadRepository positionReadRepository, IPositionWriteRepository positionWriteRepository)
        {
            _positionReadRepository = positionReadRepository;
            _positionWriteRepository = positionWriteRepository;
        }

        public async Task<Result> Handle(DeactivatePositionCommand request, CancellationToken cancellationToken)
        {
             var position = await _positionReadRepository.GetByIdAsync(request.PositionId);
            if (position is null)
                return Result.Failure("Position not found");

            position.Deactivate();

            await _positionWriteRepository.SaveChangesAsync();

            return Result.Success();    
        }
    }
}
