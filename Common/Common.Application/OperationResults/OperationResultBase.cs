using Common.Application.OperationResults.Enums;

namespace Common.Application.OperationResults;

public abstract class OperationResultBase
{
    public string Message { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public OperationResultStatus Status { get; set; }

    protected OperationResultBase() { }

    protected OperationResultBase(OperationResultStatus status, string message, string title = "")
    {
        Status = status;
        Message = message;
        Title = title;
    }
}