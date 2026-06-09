using Application.Common.Results;
using Application.Interfaces.Repositories.Read.Common;
using Application.Interfaces.Repositories.Write.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Positions.Command.CreatePosition
{
    public sealed class CreatePositionCommandHandler : IRequestHandler<CreatePositionCommand, Result<Guid>>
    {
        private readonly IPositionReadRepository _positionReadRepository;
        private readonly IPositionWriteRepository _positionWriteRepository;

        public CreatePositionCommandHandler(IPositionReadRepository positionReadRepository, IPositionWriteRepository positionWriteRepository)
        {
            _positionReadRepository = positionReadRepository;
            _positionWriteRepository = positionWriteRepository;
        }

        public async Task<Result<Guid>> Handle(CreatePositionCommand request, CancellationToken cancellationToken)
        {
            var isExists = await _positionReadRepository.CheckPositionByNameAsync(request.Name);

            if (isExists)
                return Result<Guid>.Failure("This Position already exists");

            Position position = Position.Create(request.Name);

            await _positionWriteRepository.AddAsync(position);
            await _positionWriteRepository.SaveChangesAsync();

            return Result<Guid>.Success(position.Id);
        }
    }
}
