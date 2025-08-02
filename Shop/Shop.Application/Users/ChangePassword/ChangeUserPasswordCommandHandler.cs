using Common.Application;
using Common.Application.OperationResults;
using Common.Application.SecurityUtil;
using Common.Application.UnitOfWork;
using Shop.Domain.UserAgg.Repository;

namespace Shop.Application.Users.ChangePassword;

public class ChangeUserPasswordCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork) : IBaseCommandHandler<ChangeUserPasswordCommand>
{
    public async Task<OperationResult> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdTrackingAsync(request.UserId);
        if (user == null) return OperationResult.NotFound();
        if (user.Password != request.CurrentPassword.ToMd5()) return OperationResult.Error("کلمه عبور فعلی صحیح نمیباشد");
        
        user.ChangePassword(request.Password);
        await unitOfWork.SaveChangesAsync();
        return OperationResult.Success();
    }
}