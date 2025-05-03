using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using MenuAPI.Infrastructure.Exceptions;

namespace MenuAPI.Infrastructure.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An exception occurred: {Message}", ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/problem+json";

            var (statusCode, title, detail, timestamp, type) = GetExceptionMetadata(exception);

            var extendedProblemDetails = new ExtendedProblemDetails
            {
                Type = type,
                Title = title,
                Status = (int)statusCode,
                Detail = detail,
                Instance = context.Request.Path,
                Timestamp = timestamp.ToString("o")
            };

            if(exception is ValidationException validationEx)
            {
                extendedProblemDetails.Detail = "One or more validation errors occurred.";
                extendedProblemDetails.Errors = validationEx.Errors.ToDictionary();
            }

            context.Response.StatusCode = (int)statusCode;

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            var json = JsonSerializer.Serialize(extendedProblemDetails, options);
            await context.Response.WriteAsync(json);
        }

        private (HttpStatusCode StatusCode, string Title, string Detail, DateTime Timestamp, string Type) GetExceptionMetadata(Exception ex)
        {
            var vietnamTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time"));

            return ex switch
            {
                BadRequestException badRequestEx => (
                    HttpStatusCode.BadRequest,
                    "Bad Request",
                    badRequestEx.Message,
                    vietnamTime,
                    "https://example.com/probs/bad-request"
                ),
                NotFoundException notFoundEx => (
                    HttpStatusCode.NotFound,
                    "Resource Not Found",
                    notFoundEx.Message,
                    vietnamTime,
                    "https://example.com/probs/not-found"
                ),
                ValidationException validationEx => (
                    HttpStatusCode.BadRequest,
                    "Validation Error",
                    validationEx.Message,
                    vietnamTime,
                    "https://example.com/probs/validation-error"
                ),
                UnauthorizedException unauthorizedEx => (
                    HttpStatusCode.Unauthorized,
                    "Unauthorized",
                    unauthorizedEx.Message,
                    vietnamTime,
                    "https://example.com/probs/unauthorized"
                ),
                OperationCanceledException => (
                    HttpStatusCode.RequestTimeout,
                    "Request Canceled",
                    "The request was canceled by the client or server",
                    vietnamTime,
                    "https://example.com/probs/canceled"
                ),
                _ => (
                    HttpStatusCode.InternalServerError,
                    "Server Error",
                    _env.IsDevelopment() ? ex.Message : "An unexpected error occurred",
                    vietnamTime,
                    "https://example.com/probs/server-error"
                )
            };

        }
    }
}
