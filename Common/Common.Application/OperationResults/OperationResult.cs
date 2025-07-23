using Common.Application.OperationResults.Enums;

namespace Common.Application.OperationResults;

public class OperationResult : OperationResultBase
{
    private OperationResult(OperationResultStatus status, string message, string title = "") 
        : base(status, message, title) { }

    public static OperationResult Success(string message = "عملیات با موفقیت انجام شد") =>
        new OperationResult(OperationResultStatus.Success, message);

    public static OperationResult Error(string message = "عملیات با شکست مواجه شد") =>
        new OperationResult(OperationResultStatus.Error, message, "خطا");

    public static OperationResult NotFound(string message = "اطلاعات یافت نشد") =>
        new OperationResult(OperationResultStatus.NotFound, message, "یافت نشد");
}

public class OperationResult<TData> : OperationResultBase
{
    public TData Data { get; set; }

    private OperationResult(OperationResultStatus status, string message, TData data, string title = "")
        : base(status, message, title)
    {
        Data = data;
    }

    public static OperationResult<TData> Success(TData data, string message = "عملیات با موفقیت انجام شد") =>
        new OperationResult<TData>(OperationResultStatus.Success, message, data);

    public static OperationResult<TData> Error(string message = "عملیات با شکست مواجه شد") =>
        new OperationResult<TData>(OperationResultStatus.Error, message, default!, "خطا");

    public static OperationResult<TData> NotFound() =>
        new OperationResult<TData>(OperationResultStatus.NotFound, "اطلاعات یافت نشد", default!, "یافت نشد");
}