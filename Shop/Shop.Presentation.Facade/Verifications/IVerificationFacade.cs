using Common.Application.OperationResults;
using Shop.Application.Verifications.RequestCode;
using Shop.Application.Verifications.VerifyCode;

namespace Shop.Presentation.Facade.Verifications;

public interface IVerificationFacade
{
    Task<OperationResult> RequestCode(RequestCodeCommand command);
    Task<OperationResult> VerifyCode(VerifyCodeCommand command);
}