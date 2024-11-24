using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace ifst.API.ifst.API.Middleware;

public class ValidationMiddleware
{
    private readonly RequestDelegate _next;

    public ValidationMiddleware(RequestDelegate next)
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
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Response.ContentType = "application/json";

            var problemDetails = new ValidationProblemDetails
            {
                Title = ".خطایی رخ داده است",
                Status = StatusCodes.Status400BadRequest,
                // Instance = context.Request.Path
            };

            foreach (var error in ex.Errors)
            {
                problemDetails.Errors.Add(error.PropertyName, new[] { error.ErrorMessage });
            }

            await context.Response.WriteAsJsonAsync(problemDetails);
        }
    }
}

//                Type = "https://tools.ietf.org/html/rfc9110#section-15.5.1",

