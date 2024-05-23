using SistemaPedidos.Domain.Exceptions;

namespace SistemaPedidos.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
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
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // Log the exception (optional)
            Console.WriteLine($"An error occurred: {exception}");
            // Set response status code based on the type of exception
            int statusCode = StatusCodes.Status500InternalServerError; // Default to internal server error
            if (exception is BadRequestException)
            {
                statusCode = StatusCodes.Status400BadRequest;
            }

            // Set the response content type to JSON
            context.Response.ContentType = "application/json";

            // Set the response status code and write the error message
            context.Response.StatusCode = statusCode;
            return context.Response.WriteAsync(new
            {
                StatusCode = statusCode,
                Message = exception.Message
            }.ToString());
        }
    }

    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
