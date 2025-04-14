namespace Vypex.Employee.WebApi.Core
{
    public class VypexLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public VypexLoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<VypexLoggingMiddleware>();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation($"Incoming Request: {context.Request.Method} {context.Request.Path}");

            await _next(context);

            _logger.LogInformation($"Outgoing Response: {context.Response.StatusCode} for {context.Request.Method} {context.Request.Path}");
        }
    }
}
