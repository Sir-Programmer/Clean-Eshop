namespace Common.AspNetCore;

public class ApiResult
{
    public bool IsSuccess { get; set; }
    public required MetaData MetaData { get; set; }
}

public class ApiResult<TData>
{
    public bool IsSuccess { get; set; }
    public required TData Data { get; set; }
    public required MetaData MetaData { get; set; }
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