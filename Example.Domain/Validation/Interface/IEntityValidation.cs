namespace Example.Domain.Validation
{
    public interface IEntityValidation<T>
    {
        bool IsValid(T entity);
    }
}