using Common.Application;
using Common.Application.OperationResults;
using Common.Application.UnitOfWork;
using Common.Domain.Utils;
using Shop.Domain.VerificationAgg;
using Shop.Domain.VerificationAgg.Repository;
using Shop.Domain.VerificationAgg.Services;

namespace Shop.Application.Verifications.RequestCode;

public class RequestCodeCommandHandler(IVerificationRepository verificationRepository, IUnitOfWork unitOfWork, IVerificationDomainService verificationDomainService) : IBaseCommandHandler<RequestCodeCommand>
{
    public async Task<OperationResult> Handle(RequestCodeCommand request, CancellationToken cancellationToken)
    {
        var code = TextHelper.GenerateCode(6);
        //TODO: SMS This Code
        var verification = new Verification(request.PhoneNumber, code, verificationDomainService);
        await verificationRepository.AddAsync(verification);
        await unitOfWork.SaveChangesAsync();
        return OperationResult.Success();
    }
}