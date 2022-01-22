using AIHR.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Data.Common;
using System.Net;
using System.Threading.Tasks;

namespace Workload.WebApi.MiddleWares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            _logger.LogError(exception.Message, exception);

            var code = HttpStatusCode.InternalServerError;
            var message = exception.Message;

           
            switch (exception)
            {
                case NotImplementedException:
                    {
                        code = HttpStatusCode.NotImplemented;
                        message = "This feature will be implemented as soon as possible.";
                        _logger.LogError("Not Implemented method is visible ," + exception);
                        break;
                    }
                case FormatException:
                    {
                        code = HttpStatusCode.BadRequest;
                        message = "format is invalid.";
                        _logger.LogError("format is invalid. ," + exception);
                        break;
                    }
                case DbException:
                    {
                        code = HttpStatusCode.InternalServerError;
                        message = "Error occured in db operations.";
                        _logger.LogError("DbException: ," + exception);
                        break;
                    }
                case NullReferenceException:
                    {
                        code = HttpStatusCode.BadRequest;
                        message = "Object can not be null.";
                        break;
                    }
                case TimeoutException:
                    {
                        code = HttpStatusCode.BadRequest;
                        message = "Time out Error.";
                        break;
                    }
                case System.Text.Json.JsonException:
                    {
                        code = HttpStatusCode.BadRequest;
                        message = "Json Convertion Error.";
                        break;
                    }
                default:
                    {
                        _logger.LogError($"A new UnexpectedException has been thrown: {exception}");
                        break;
                    }
            }

            
            context.Session.SetInt32("StatusCode", (int)code);
            context.Session.SetString("Message", message);

            context.Response.Redirect("/Home/Error");
            await context.Response.WriteAsync(new ErrorViewModel()
            {
                StatusCode = (int)code,
                Message = message,
            }.ToString());
        }
    }
}
