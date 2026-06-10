using Application.Common.Results;
using Application.Features.Positions.DTOs;
using Application.Interfaces.Repositories.Read.Common;
using Application.Interfaces.Repositories.Write.Common;
using MediatR;

namespace Application.Features.Positions.Queries.GetAllPositions
{
    public sealed class GetAllPositionsQueryHandler : IRequestHandler<GetAllPositionsQuery, Result<List<PositionDto>>>
    {
        private readonly IPositionReadRepository _positionReadRepository;

        public GetAllPositionsQueryHandler(IPositionReadRepository positionReadRepository)
        {
            _positionReadRepository = positionReadRepository;
        }

        public async Task<Result<List<PositionDto>>> Handle(GetAllPositionsQuery request, CancellationToken cancellationToken)
        {
            var positions = await _positionReadRepository.GetAllAsync();
            if (positions is null)
                return Result<List<PositionDto>>.Failure("Positions not found");

            var result = positions.Select(x => new PositionDto(
                x.Id,
                x.Name,
                x.IsActive)).ToList();

            return Result<List<PositionDto>>.Success(result);
        }
    }
}
