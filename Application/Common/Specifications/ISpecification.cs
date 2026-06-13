namespace Application.Common.Specifications
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T specification);
    }
}
