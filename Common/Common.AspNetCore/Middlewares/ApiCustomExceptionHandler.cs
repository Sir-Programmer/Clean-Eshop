using System.Net;
using Common.Application.Exceptions;
using Common.Domain.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Common.AspNetCore.Middlewares;

public static class ApiCustomExceptionHandlerMiddlewareExtensions
{
    public static IApplicationBuilder UseApiCustomExceptionHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ApiCustomExceptionHandlerMiddleware>();
    }
}

public class ApiCustomExceptionHandlerMiddleware(RequestDelegate next, IHostingEnvironment env, ILogger<ApiCustomExceptionHandlerMiddleware> logger)
{
    public async Task Invoke(HttpContext context)
    {
        var message = "Exception";
        var httpStatusCode = HttpStatusCode.InternalServerError;
        var apiStatusCode = OperationStatusCode.ServerError;

        try
        {
            await next(context);
        }
        catch (InvalidDomainDataException exception)
        {
            logger.LogError(exception, exception.Message);
            apiStatusCode = OperationStatusCode.LogicError;
            SetErrorMessage(exception);
            await WriteToResponseAsync();
        }
        catch (InvalidCommandException exception)
        {
            logger.LogError(exception, exception.Message);
            httpStatusCode = HttpStatusCode.BadRequest;
            SetErrorMessage(exception);
            await WriteToResponseAsync();
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            SetErrorMessage(exception);
            await WriteToResponseAsync();
        }

        return;

        void SetErrorMessage(Exception exception)
        {
            message = exception.Message;
            if (!env.IsDevelopment()) return;
            var dic = new Dictionary<string, string?>
            {
                ["Exception"] = exception.Message,
                ["StackTrace"] = exception.StackTrace,
            };
            if (exception.InnerException != null)
            {
                dic.Add("InnerException.Exception", exception.InnerException.Message);
                if (exception.InnerException.StackTrace != null)
                    dic.Add("InnerException.StackTrace", exception.InnerException.StackTrace);
            }

            message = JsonConvert.SerializeObject(dic);
        }

        async Task WriteToResponseAsync()
        {
            if (context.Response.HasStarted)
                throw new InvalidOperationException("The response has already started, the http status code middleware will not be executed.");

            var result = new ApiResult()
            {
                IsSuccess = false,
                MetaData = new MetaData
                {
                    OperationStatusCode = apiStatusCode,
                    Message = message
                }
            };
            var json = JsonConvert.SerializeObject(result);

            context.Response.StatusCode = (int)httpStatusCode;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(json);
        }
    }
}