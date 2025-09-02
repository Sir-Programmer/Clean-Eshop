using System.Net;
using Common.Application.OperationResults;
using Common.Application.OperationResults.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Common.AspNetCore;

[Route("api/[controller]")]
[ApiController]
public class ApiController : ControllerBase
{
    protected ApiResult CommandResult(OperationResult result)
    {
        return new ApiResult()
        {
            IsSuccess = result.Status == OperationResultStatus.Success,
            MetaData = new MetaData
            {
                Message = result.Message,
                OperationStatusCode = result.Status.MapOperationStatus()
            }
        };
    }
    protected ApiResult<TData?> CommandResult<TData>(OperationResult<TData> result, HttpStatusCode statusCode = HttpStatusCode.OK, string? locationUrl = null)
    {
        var isSuccess = result.Status == OperationResultStatus.Success;
        HttpContext.Response.StatusCode = (int)statusCode;
        if (!isSuccess)
            return new ApiResult<TData?>
            {
                IsSuccess = isSuccess,
                Data = isSuccess ? result.Data : default,
                MetaData = new MetaData
                {
                    Message = result.Message,
                    OperationStatusCode = result.Status.MapOperationStatus()
                }
            };
        
        if (!string.IsNullOrWhiteSpace(locationUrl))
        {
            HttpContext.Response.Headers.Add("location", locationUrl);
        }
        return new ApiResult<TData?>
        {
            IsSuccess = isSuccess,
            Data = isSuccess ? result.Data : default,
            MetaData = new MetaData
            {
                Message = result.Message,
                OperationStatusCode = result.Status.MapOperationStatus()
            }
        };
    }
    
    protected ApiResult<TData?> QueryResult<TData>(TData? result) where TData : class
    {
        if (result != null)
            return ApiResult<TData?>.Success(result);

        HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
        return ApiResult<TData?>.NotFound(null);
    }

    protected ApiResult<List<T>> QueryResult<T>(List<T>? result)
    {
        return ApiResult<List<T>>.Success(result ?? []);
    }
}