using System.Collections.Generic;

namespace Example.Domain.Validation.Interface
{
    public interface IBaseValidation<T>
    {
        List<ValidationMessage> messages { get; set; }
        bool isValid { get;}
        void Validate(T entity);
    }
}