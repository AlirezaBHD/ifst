using FluentValidation;
using FluentValidation.Results;

namespace JsonPatchSample.ifst.Domain.ValueObjects;

public class NationalCode
{
    private readonly string _value;

    public string Value => _value;

    public NationalCode(string value)
    {
        if (!IsValidNationalCode(value))
        {
            var errors = new List<ValidationFailure>
            {
                new ValidationFailure("NationalCode", ".کد ملی وارد شده اشتباه است")
            };

            throw new ValidationException("Validation Error", errors);
        }

        _value = value;
    }

    private static bool IsValidNationalCode(string code)
    {
        if (string.IsNullOrWhiteSpace(code) || code.Length != 10 || !code.All(char.IsDigit))
            return false;

        var check = int.Parse(code.Substring(9, 1));
        var sum = code.Substring(0, 9).Select((x, i) => int.Parse(x.ToString()) * (10 - i)).Sum();
        var remainder = sum % 11;

        return (remainder < 2 && check == remainder) || (remainder >= 2 && check + remainder == 11);
    }

    public override string ToString() => _value;
}