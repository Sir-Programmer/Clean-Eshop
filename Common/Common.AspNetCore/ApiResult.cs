namespace Common.AspNetCore;

public class ApiResult
{
    public bool IsSuccess { get; set; }
    public required MetaData MetaData { get; set; }
    
    public static ApiResult Create(OperationStatusCode code, string message, bool isSuccess) => new()
    {
        IsSuccess = isSuccess,
        MetaData = new MetaData
        {
            Message = message,
            OperationStatusCode = code
        }
    };

    public static ApiResult Success(string message = "عملیات با موفقیت انجام شد") 
        => Create(OperationStatusCode.Success, message, true);

    public static ApiResult NotFound(string message = "یافت نشد") 
        => Create(OperationStatusCode.NotFound, message, false);

    public static ApiResult BadRequest(string message = "درخواست نامعتبر است") 
        => Create(OperationStatusCode.BadRequest, message, false);

    public static ApiResult LogicError(string message = "خطای منطقی رخ داده است") 
        => Create(OperationStatusCode.LogicError, message, false);

    public static ApiResult UnAuthorize(string message = "دسترسی غیرمجاز") 
        => Create(OperationStatusCode.UnAuthorize, message, false);

    public static ApiResult ServerError(string message = "خطای داخلی سرور") 
        => Create(OperationStatusCode.ServerError, message, false);
}

public class ApiResult<TData>
{
    public bool IsSuccess { get; set; }
    public required TData Data { get; set; }
    public required MetaData MetaData { get; set; }

    private static ApiResult<TData> Create(OperationStatusCode code, TData data, string message, bool isSuccess) => new()
    {
        IsSuccess = isSuccess,
        Data = data,
        MetaData = new MetaData
        {
            Message = message,
            OperationStatusCode = code
        }
    };

    public static ApiResult<TData> Success(TData data, string message = "عملیات با موفقیت انجام شد") 
        => Create(OperationStatusCode.Success, data, message, true);

    public static ApiResult<TData> NotFound(TData data, string message = "یافت نشد") 
        => Create(OperationStatusCode.NotFound, data, message, false);

    public static ApiResult<TData> BadRequest(TData data, string message = "درخواست نامعتبر است") 
        => Create(OperationStatusCode.BadRequest, data, message, false);

    public static ApiResult<TData> LogicError(TData data, string message = "خطای منطقی رخ داده است") 
        => Create(OperationStatusCode.LogicError, data, message, false);

    public static ApiResult<TData> UnAuthorize(TData data, string message = "دسترسی غیرمجاز") 
        => Create(OperationStatusCode.UnAuthorize, data, message, false);

    public static ApiResult<TData> ServerError(TData data, string message = "خطای داخلی سرور") 
        => Create(OperationStatusCode.ServerError, data, message, false);
}

public class MetaData
{
    public OperationStatusCode OperationStatusCode { get; set; }
    public required string Message { get; set; }
}


public enum OperationStatusCode
{
    Success = 1000,
    NotFound = 1001,
    BadRequest = 1002,
    LogicError = 1003,
    UnAuthorize = 1004,
    ServerError = 1005
}