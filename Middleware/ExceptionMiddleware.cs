using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MovieBuff.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace MovieBuff.Middleware
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
                if (_env.IsDevelopment())
                {
                    _logger.LogError(ex, ex.Message);
                }

                await HandleExceptionAsync(context, (int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, int statusCode, string errorMsg = "Internal Server Error")
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            var errorDetails = new ErrorDetails
            {
                StatusCode = statusCode,
                Message = errorMsg
            };

            var serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            return context.Response.WriteAsync(JsonSerializer.Serialize(errorDetails, serializeOptions));
        }
    }
}
