using Common.Application.OperationResults.Enums;

namespace Common.AspNetCore;

public static class ResultMapper
{
    public static OperationStatusCode MapOperationStatus(this OperationResultStatus status)
    {
        return status switch
        {
            OperationResultStatus.Success => OperationStatusCode.Success,
            OperationResultStatus.NotFound => OperationStatusCode.NotFound,
            OperationResultStatus.Error => OperationStatusCode.LogicError,
            _ => OperationStatusCode.LogicError
        };
    }
}