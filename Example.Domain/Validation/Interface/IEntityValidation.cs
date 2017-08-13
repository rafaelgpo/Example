namespace Example.Domain.Validation
{
    public interface IEntityValidation<T>
    {
        bool isValid { get; }
        ValidationMessages messages { get; set; }
    }
}