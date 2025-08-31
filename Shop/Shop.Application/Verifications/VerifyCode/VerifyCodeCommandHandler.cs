using Common.Application;
using Common.Application.OperationResults;
using Common.Application.UnitOfWork;
using Shop.Domain.VerificationAgg.Repository;

namespace Shop.Application.Verifications.VerifyCode;

public class VerifyCodeCommandHandler(IVerificationRepository verificationRepository, IUnitOfWork unitOfWork) : IBaseCommandHandler<VerifyCodeCommand>
{
    public async Task<OperationResult> Handle(VerifyCodeCommand request, CancellationToken cancellationToken)
    {
        var verification = await verificationRepository.GetLastVerificationDataByPhoneNumberAsync(request.PhoneNumber);
        if (verification == null) 
            return OperationResult.Error("کدی برای این شماره پیدا نشد یا منقضی شده است");
        if (!verification.Verify(request.Code)) 
            return OperationResult.Error("کد وارد شده صحیح نیست");
        await unitOfWork.SaveChangesAsync();
        return OperationResult.Success();
    }
}