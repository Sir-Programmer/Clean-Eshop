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
        HttpContext.Response.StatusCode = (int)statusCode;
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
            return new ApiResult<TData?>
            {
                IsSuccess = true,
                Data = result,
                MetaData = new MetaData
                {
                    Message = "عملیات با موفقیت انجام شد",
                    OperationStatusCode = OperationStatusCode.Success
                }
            };
        
        HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
        return new ApiResult<TData?>
        {
            IsSuccess = false,
            Data = null,
            MetaData = new MetaData
            {
                Message = "موردی یافت نشد",
                OperationStatusCode = OperationStatusCode.NotFound
            }
        };
    }
    
    protected ApiResult<List<T>> QueryResult<T>(List<T>? result)
    {
        return new ApiResult<List<T>>
        {
            IsSuccess = true,
            Data = result ?? [], 
            MetaData = new MetaData
            {
                Message = "عملیات با موفقیت انجام شد",
                OperationStatusCode = OperationStatusCode.Success
            }
        };
    }
}