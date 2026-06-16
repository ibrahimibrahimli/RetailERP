namespace Application.Common.Specifications
{
    public interface ISpecification<T>
    {
        SpecificationResult IsSatisfiedBy(T entity);
    }
}
