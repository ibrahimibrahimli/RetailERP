namespace Application.Common.Specifications
{
    public sealed record SpecificationResult(
        bool IsSatisfied,
        string? Reason = null);
}
