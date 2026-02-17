using System.Net;
using System.Text.Json;
using MediaTracker.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace MediaTracker.Api.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (NotFoundException ex)
        {
            await HandleException(context, HttpStatusCode.NotFound, "Resource not found", ex.Message);
        }
        catch (BusinessRuleException ex)
        {
            await HandleException(context, HttpStatusCode.BadRequest, "Business rule violation", ex.Message);
        }
        catch (Exception)
        {
            await HandleException(context, HttpStatusCode.InternalServerError, "Unexpected error", "Internal server error");
        }
    }

    private static async Task HandleException(
        HttpContext context,
        HttpStatusCode status,
        string title,
        string detail)
    {
        var problem = new ProblemDetails
        {
            Title = title,
            Detail = detail,
            Status = (int)status,
            Type = $"https://httpstatuses.com/{(int)status}",
            Instance = context.Request.Path
        };

        context.Response.ContentType = "application/problem+json";
        context.Response.StatusCode = (int)status;

        var json = JsonSerializer.Serialize(problem);

        await context.Response.WriteAsync(json);
    }
}
