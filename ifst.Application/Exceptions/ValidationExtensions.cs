using FluentValidation;
using FluentValidation.Results;

namespace ifst.API.ifst.Application.Exceptions;

public static class ValidationExtensions
{
    public static void ThrowIfNull<T>(this T entity, string displayName)
    {
        if (entity == null)
        {
            var errors = new List<ValidationFailure>
            {
                new ValidationFailure(typeof(T).Name, $".{displayName} یافت نشد")
            };

            throw new ValidationException("Validation Error", errors);
        }
    }
    
}