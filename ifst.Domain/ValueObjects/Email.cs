using System.Text.RegularExpressions;
using FluentValidation;
using FluentValidation.Results;

namespace JsonPatchSample.ifst.Domain.ValueObjects;

public class Email
{
    private static readonly Regex EmailRegex = new Regex(
        @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public string Value { get; }

    public Email(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            var errors = new List<ValidationFailure>
            {
                new ValidationFailure("Email", ".ایمیل نمی‌تواند خالی باشد")
            };

            throw new ValidationException("Validation Error", errors);
        }

        if (!EmailRegex.IsMatch(value))
        {
            var errors = new List<ValidationFailure>
            {
                new ValidationFailure("Email", ".ایمیل وارد شده معتبر نیست")
            };

            throw new ValidationException("Validation Error", errors);
        }
        
        Value = value;
    }

    public override string ToString() => Value;

    public override bool Equals(object? obj)
    {
        if (obj is Email other)
            return string.Equals(Value, other.Value, StringComparison.OrdinalIgnoreCase);

        return false;
    }

    public override int GetHashCode() => Value.ToLowerInvariant().GetHashCode();

    public static implicit operator string(Email email) => email.Value;
    public static explicit operator Email(string value) => new Email(value);
}