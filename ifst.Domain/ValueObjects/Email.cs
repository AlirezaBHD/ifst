using System.Text.RegularExpressions;
using FluentValidation;
using FluentValidation.Results;

namespace ifst.API.ifst.Domain.ValueObjects;

public class Email
{
    public static Regex EmailRegex = new Regex(
        @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public static bool IsValidEmail(string? email)
    {
        if (email != null)
        {
            return EmailRegex.IsMatch(email);
        }

        return true;
    }
}