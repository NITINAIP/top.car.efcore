using System.Net;
using System.Text.Json;
using top.car.service.Application.Exceptions;


namespace top.car.service.API.Middlewares;

public sealed class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
       
        catch (NotFoundException ex)
        {
            await HandleNotFoundException(context, ex);
        }
        catch (Exception ex)
        {
            await HandleGenericException(context, ex);
        }
    }
    private async Task HandleGenericException(HttpContext context, Exception ex)
    {
        _logger.LogError(ex, "HandleGenericException");
        
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var payload = new
        {
            error = "InternalServerError",
            message = "An unexpected error occurred."
        };

        await context.Response.WriteAsync(JsonSerializer.Serialize(payload));
    }
    private async Task HandleNotFoundException(HttpContext context, NotFoundException ex)
    {
        _logger.LogError(ex, "HandleNotFoundException");
        
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.NotFound;

        var payload = new
        {
            error = "NotFound",
            message = ex.Message
        };

        await context.Response.WriteAsync(JsonSerializer.Serialize(payload));
    }
}