using motorsports_Domain.Exceptions;
using System.Net;
using System.Text.Json;

namespace motorsports_backend.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        public readonly RequestDelegate _next;
        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
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
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = exception switch
            {
                UserCreationError => HttpStatusCode.InternalServerError,
                PasswordMismatch => HttpStatusCode.Unauthorized,
                DuplicateUsernameException => HttpStatusCode.Conflict,
                DuplicateUserEmail => HttpStatusCode.Conflict,
                UserRoleCreationError => HttpStatusCode.BadRequest,
                UserNotFound => HttpStatusCode.NotFound,
                RecordNotFound => HttpStatusCode.NotFound,
                ArgumentNullException => HttpStatusCode.BadRequest,
                ArgumentException => HttpStatusCode.BadRequest,
                _ => HttpStatusCode.InternalServerError
            };
            var response = new { message = exception.Message };
            var json = JsonSerializer.Serialize(response);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(json);
        }
    }
}
