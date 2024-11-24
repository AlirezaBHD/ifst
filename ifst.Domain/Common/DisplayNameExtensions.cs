namespace ifst.API.ifst.Domain.Common;

public static class DisplayNameExtensions
{
    public static string GetDisplayName<T>()
    {
        var displayNameAttribute = typeof(T).GetCustomAttributes(typeof(DisplayNameAttribute), false)
            .FirstOrDefault() as DisplayNameAttribute;

        return displayNameAttribute?.Name ?? typeof(T).Name;
    }
}