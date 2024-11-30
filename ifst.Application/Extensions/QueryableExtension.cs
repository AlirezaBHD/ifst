using System.Linq.Expressions;

namespace ifst.API.ifst.Application.Extensions;

public static class QueryableExtensions
{
    public static IQueryable<T> ApplyFilters<T>(this IQueryable<T> query, object filter)
    {
        if (filter == null) return query;

        var filterProperties = filter.GetType().GetProperties();

        foreach (var property in filterProperties)
        {
            var value = property.GetValue(filter);
            if (value == null) continue; // اگر مقدار فیلد نال بود، از آن عبور کن

            var parameter = Expression.Parameter(typeof(T), "x");
            var member = Expression.Property(parameter, property.Name);
            var constant = Expression.Constant(value);
            Expression predicate;

            // بررسی نوع شرط
            if (property.PropertyType == typeof(string))
            {
                var method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                predicate = Expression.Call(member, method, constant);
            }
            else
            {
                predicate = Expression.Equal(member, constant);
            }

            var lambda = Expression.Lambda<Func<T, bool>>(predicate, parameter);
            query = query.Where(lambda);
        }

        return query;
    }
}
