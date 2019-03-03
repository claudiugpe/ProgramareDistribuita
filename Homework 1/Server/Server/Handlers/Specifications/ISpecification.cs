namespace Server.Handlers.Specifications
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T model);
    }
}