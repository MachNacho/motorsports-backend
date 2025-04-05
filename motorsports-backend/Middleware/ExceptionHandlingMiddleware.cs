using motorsports_Domain.Exceptions;
using motorsports_Infrastructure.Exceptions;
using motorsports_Service.Exceptions;
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
                EmptyOrNoRecordsException => HttpStatusCode.NoContent,
                NotFoundException => HttpStatusCode.NotFound,
                ValidationException => HttpStatusCode.BadRequest,
                DuplicateRecordException => HttpStatusCode.Conflict,
                BusinessRuleViolationException => HttpStatusCode.BadRequest,
                UnauthorizedException => HttpStatusCode.Unauthorized,
                ForbiddenException => HttpStatusCode.Forbidden,
                OperationFailedException => HttpStatusCode.InternalServerError,
                DatabaseException => HttpStatusCode.InternalServerError,
                ExternalServiceException => HttpStatusCode.BadGateway,
                FileStorageException => HttpStatusCode.InternalServerError,
                // BadRequestException => HttpStatusCode.BadRequest,
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
