namespace Application.Features.Brands.Dtos
{
    public sealed record BrandDto(
        Guid Id,
        string Name,
        bool IsActive,
        string SubCompanyName);
}
