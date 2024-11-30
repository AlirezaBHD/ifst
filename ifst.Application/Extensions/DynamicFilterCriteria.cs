using System.Linq.Expressions;

namespace ifst.API.ifst.Application.Extensions;

public class DynamicFilterCriteria<T>
{
    private readonly List<Expression<Func<T, bool>>> _filters = new();

    public void AddFilter(string propertyName, string value)
    {
        var parameter = Expression.Parameter(typeof(T), "x");
        var property = Expression.Property(parameter, propertyName);
        var valueExpression = Expression.Constant(value);

        var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
        var containsExpression = Expression.Call(property, containsMethod!, valueExpression);

        var lambda = Expression.Lambda<Func<T, bool>>(containsExpression, parameter);
        _filters.Add(lambda);
    }

    public Expression<Func<T, bool>>? GeneratePredicate()
    {
        if (_filters.Count == 0) return null;

        var parameter = Expression.Parameter(typeof(T), "x");
        Expression? body = null;

        foreach (var filter in _filters)
        {
            var invokedFilter = Expression.Invoke(filter, parameter);
            body = body == null ? invokedFilter : Expression.AndAlso(body, invokedFilter);
        }

        return body == null ? null : Expression.Lambda<Func<T, bool>>(body, parameter);
    }
}
