using FluentValidation;
using FluentValidation.Results;

namespace ifst.API.ifst.Domain.ValueObjects;

public class NationalCode
{
    public static bool IsValidNationalCode(string code)
    {
        if (string.IsNullOrWhiteSpace(code) || code.Length != 10 || !code.All(char.IsDigit))
            return false;

        var check = int.Parse(code[^1].ToString());
        var sum = code[..9].Select((c, i) => int.Parse(c.ToString()) * (10 - i)).Sum();
        var remainder = sum % 11;

        return (remainder < 2 && check == remainder) || (remainder >= 2 && check + remainder == 11);
    }

}
