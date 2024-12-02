using FluentValidation;
using System.Text.Json;

namespace ifst.API.ifst.API.Middleware;


public class ValidationExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ValidationExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException ex)
        {
            await HandleValidationExceptionAsync(context, ex);
        }
        catch (Exception ex)
        {
            await HandleGeneralExceptionAsync(context, ex);
        }
    }

    private Task HandleValidationExceptionAsync(HttpContext context, ValidationException ex)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = StatusCodes.Status400BadRequest;

        var response = new
        {
            type = "https://tools.ietf.org/html/rfc9110#section-15.5.1",
            title = "Validation Error",
            status = 400,
            errors = ex.Errors.ToDictionary(e => e.PropertyName, e => new[] { e.ErrorMessage })
        };

        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }

    private Task HandleGeneralExceptionAsync(HttpContext context, Exception ex)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;

        var response = new
        {
            type = "https://tools.ietf.org/html/rfc9110#section-15.6.1",
            title = "Internal Server Error",
            status = 500,
            detail = ex.Message
        };

        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}
