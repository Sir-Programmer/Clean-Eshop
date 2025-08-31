using Common.Application.OperationResults;
using MediatR;
using Shop.Application.Verifications.RequestCode;
using Shop.Application.Verifications.VerifyCode;

namespace Shop.Presentation.Facade.Verifications;

public class VerificationFacade(IMediator mediator) : IVerificationFacade
{
    public async Task<OperationResult> RequestCode(RequestCodeCommand command)
    {
        return await mediator.Send(command);
    }

    public async Task<OperationResult> VerifyCode(VerifyCodeCommand command)
    {
        return await mediator.Send(command);
    }
}