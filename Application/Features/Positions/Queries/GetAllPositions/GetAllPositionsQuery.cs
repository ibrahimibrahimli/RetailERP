using Application.Common.Results;
using Application.Features.Positions.DTOs;
using MediatR;

namespace Application.Features.Positions.Queries.GetAllPositions
{
    public sealed record GetAllPositionsQuery() : IRequest<Result<List<PositionDto>>>;
}
