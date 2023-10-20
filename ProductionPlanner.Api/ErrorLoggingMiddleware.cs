namespace ProductionPlanner.Api;

public class ErrorLoggingMiddleware
{
    private readonly ILogger<ErrorLoggingMiddleware> _logger;
    private readonly RequestDelegate _next;

    public ErrorLoggingMiddleware(
        ILogger<ErrorLoggingMiddleware> logger,
        RequestDelegate next)
    {
        _logger = logger;
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            throw;
        }
    }
}
