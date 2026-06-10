namespace Application.Features.Positions.DTOs
{
    public sealed record PositionDto(
        Guid Id,
        string Name,
        bool IsActive);
}
